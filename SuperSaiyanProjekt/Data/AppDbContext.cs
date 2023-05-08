using Microsoft.EntityFrameworkCore;
using Models;

namespace SuperSaiyanProjekt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<TimeReport> timereports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890", Age = 30, HireDate = new DateTime(2018, 5, 1) },
            new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Doe", Phone = "098-765-4321", Age = 29, HireDate = new DateTime(2019, 4, 15) },
            new Employee { EmployeeId = 3, FirstName = "Bob", LastName = "Smith", Phone = "555-555-1234", Age = 35, HireDate = new DateTime(2017, 3, 10) },
            new Employee { EmployeeId = 4, FirstName = "Alice", LastName = "Johnson", Phone = "555-555-5678", Age = 28, HireDate = new DateTime(2020, 6, 30) },
            new Employee { EmployeeId = 5, FirstName = "Charlie", LastName = "Brown", Phone = "555-555-9999", Age = 32, HireDate = new DateTime(2018, 8, 20) }
            );

            modelBuilder.Entity<Project>().HasData(
            new Project { ProjectId = 1, ProjectName = "Project A", ProjectDescription = "Description of Project A", StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 12, 31) },
            new Project { ProjectId = 2, ProjectName = "Project B", ProjectDescription = "Description of Project B", StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2023, 12, 31) }
            );

            modelBuilder.Entity<TimeReport>().HasData(
            new TimeReport { RepoId = 1, EmployeeId = 1, ProjectId = 1, WeekNumber = 1, HoursWorked = 40 },
            new TimeReport { RepoId = 2, EmployeeId = 1, ProjectId = 2, WeekNumber = 2, HoursWorked = 35 },
            new TimeReport { RepoId = 3, EmployeeId = 2, ProjectId = 1, WeekNumber = 1, HoursWorked = 30 },
            new TimeReport { RepoId = 4, EmployeeId = 3, ProjectId = 2, WeekNumber = 2, HoursWorked = 20 },
            new TimeReport { RepoId = 5, EmployeeId = 4, ProjectId = 1, WeekNumber = 3, HoursWorked = 45 },
            new TimeReport { RepoId = 6, EmployeeId = 5, ProjectId = 2, WeekNumber = 4, HoursWorked = 25 }
            );
        }
    }
}
