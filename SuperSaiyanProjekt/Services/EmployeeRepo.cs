using Microsoft.EntityFrameworkCore;
using Models;
using SuperSaiyanProjekt.Data;

namespace SuperSaiyanProjekt.Services
{
    public class EmployeeRepo : IRepository<Employee>
    {

        private readonly AppDbContext _dbContext;

        public EmployeeRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> Add(Employee entity)
        {
            await _dbContext.Set<Employee>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Get(int id)
        {
            var Employee = await _dbContext.Set<Employee>().FirstOrDefaultAsync(p => p.EmployeeId == id);
            return Employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var Employees = await _dbContext.Set<Employee>().ToListAsync();
            return Employees;
        }

        public async Task<Employee> Remove(int id)
        {
            var Employee = await _dbContext.Set<Employee>().FirstOrDefaultAsync(p => p.EmployeeId == id);
            if (Employee != null)
            {
                _dbContext.Set<Employee>().Remove(Employee);
                await _dbContext.SaveChangesAsync();
            }
            return Employee;
        }

        public async Task<Employee> Update(int id, Employee exampleEmployee)
        {
            var Employee = await _dbContext.Set<Employee>().FirstOrDefaultAsync(p => p.EmployeeId == id);
            if (Employee != null)
            {
                Employee.FirstName = exampleEmployee.FirstName;
                Employee.LastName = exampleEmployee.LastName;
                Employee.Phone = exampleEmployee.Phone;
                Employee.Age = exampleEmployee.Age;
                Employee.HireDate = exampleEmployee.HireDate;
                Employee.Projects = exampleEmployee.Projects;
                Employee.TimeReps = exampleEmployee.TimeReps;
            }
            return Employee;
        }

        

    }
}
