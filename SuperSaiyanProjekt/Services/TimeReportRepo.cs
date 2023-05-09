using Microsoft.EntityFrameworkCore;
using Models;
using SuperSaiyanProjekt.Data;

namespace SuperSaiyanProjekt.Services
{
    public class TimeReportRepo : ITimeReport
    {
        private readonly AppDbContext _dbContext;

        public TimeReportRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TimeReport> Add(TimeReport entity)
        {
            await _dbContext.Set<TimeReport>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TimeReport> Get(int id)
        {
            var TimeReport = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(p => p.RepoId == id);
            return TimeReport;
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            var TimeReports = await _dbContext.Set<TimeReport>().ToListAsync();
            return TimeReports;
        }

        public async Task<TimeReport> Remove(int id)
        {
            var TimeReport = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(p => p.RepoId == id);
            if (TimeReport != null)
            {
                _dbContext.Set<TimeReport>().Remove(TimeReport);
                await _dbContext.SaveChangesAsync();
            }
            return TimeReport;
        }

        public async Task<TimeReport> Update(int id, TimeReport exampleTimeReport)
        {
            var TimeReport = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(p => p.RepoId == id);
            if (TimeReport != null)
            {
                TimeReport.RepoId = exampleTimeReport.RepoId;
                TimeReport.EmployeeId = exampleTimeReport.EmployeeId;
                TimeReport.ProjectId = exampleTimeReport.ProjectId;
                TimeReport.WeekNumber = exampleTimeReport.WeekNumber;
                TimeReport.HoursWorked = exampleTimeReport.HoursWorked;
                TimeReport.Employee = exampleTimeReport.Employee;
                TimeReport.Project = exampleTimeReport.Project;
            }
            return TimeReport;
        }

        public async Task<TimeReport> GetHoursInWeek(int employeeid, int week)
        {
            TimeReport emp = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(e => e.Employee.EmployeeId == employeeid && e.WeekNumber == week);
            return emp;

        }
        public async Task<IEnumerable<TimeReport>> GetAllEmployeeTimeReports(int employeeid)
        {
            return null;
        }
    }
}
