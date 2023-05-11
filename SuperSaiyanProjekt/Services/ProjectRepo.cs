using Microsoft.EntityFrameworkCore;
using Models;
using SuperSaiyanProjekt.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSaiyanProjekt.Services
{
    public class ProjectRepo : IProject
    {
        private readonly AppDbContext _dbContext;

        public ProjectRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> Add(Project entity)
        {
            await _dbContext.Set<Project>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Project> Get(int id)
        {
            var project = await _dbContext.Set<Project>().FirstOrDefaultAsync(p => p.ProjectId == id);
            return project;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var projects = await _dbContext.Set<Project>().ToListAsync();
            return projects;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesForProject(int projectId)
        {
            var employees = await _dbContext.Set<Project>()
                .Include(pe => pe.Employees)
                .Where(pe => pe.ProjectId == projectId)
                .SelectMany(pe => pe.Employees)
                .ToListAsync();
            return employees;
        }

        public async Task<Project> Remove(int id)
        {
            var project = await _dbContext.Set<Project>().FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project != null)
            {
                _dbContext.Set<Project>().Remove(project);
                await _dbContext.SaveChangesAsync();
            }
            return project;
        }

        public async Task<Project> Update(int id, Project exampleProject)
        {
            var project = await _dbContext.Set<Project>().FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project != null)
            {
                project.ProjectName = exampleProject.ProjectName;
                project.ProjectDescription = exampleProject.ProjectDescription;
                project.StartDate = exampleProject.StartDate;
                project.EndDate = exampleProject.EndDate;
                await _dbContext.SaveChangesAsync();
            }
            return project;
        }
        
        public async Task<Employee> AddEmployeeToProject(int projectid, int empid)
        {
            var project = await _dbContext.projects.FirstOrDefaultAsync(x => x.ProjectId == projectid);
            var employee = await _dbContext.employees.FirstOrDefaultAsync(x => x.EmployeeId == empid);

            if (project.Employees == null)
            {
                project.Employees = new List<Employee>();
                await _dbContext.SaveChangesAsync();
            }

            if (project != null && employee != null)
            {
                project.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
            }
            return employee;
        }
    }
}
