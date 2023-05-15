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
            var TimeReport = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(p => p.TimeReportId == id);
            return TimeReport;
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            var TimeReports = await _dbContext.Set<TimeReport>().ToListAsync();
            return TimeReports;
        }

        public async Task<TimeReport> Remove(int id)
        {
            var TimeReport = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(p => p.TimeReportId == id);
            if (TimeReport != null)
            {
                _dbContext.Set<TimeReport>().Remove(TimeReport);
                await _dbContext.SaveChangesAsync();
            }
            return TimeReport;
        }

        public async Task<TimeReport> Update(int id, TimeReport exampleTimeReport)
        {
            var TimeReport = await _dbContext.Set<TimeReport>().FirstOrDefaultAsync(p => p.TimeReportId == id);
            if (TimeReport != null)
            {
                TimeReport.EmployeeId = exampleTimeReport.EmployeeId;
                TimeReport.ProjectId = exampleTimeReport.ProjectId;
                TimeReport.WeekNumber = exampleTimeReport.WeekNumber;
                TimeReport.HoursWorked = exampleTimeReport.HoursWorked;
                await _dbContext.SaveChangesAsync();
            }
            return TimeReport;
        }

        public async Task<dynamic> GetHoursInWeek(int employeeid, int week)
        {
            var emp = await _dbContext.Set<TimeReport>()
                .Where(x => x.EmployeeId == employeeid && x.WeekNumber == week)
                .Select(x => new {x.EmployeeId, x.Employee.FirstName, x.Employee.LastName, x.HoursWorked, x.WeekNumber})
                .FirstOrDefaultAsync();
            return emp;
        }
        public async Task<IEnumerable<TimeReport>> GetAllEmployeeTimeReports(int employeeid)
        {
            List<TimeReport> employee = await _dbContext.timereports.Where(x => x.EmployeeId == employeeid).ToListAsync();
            return employee;
        }
    }
}
