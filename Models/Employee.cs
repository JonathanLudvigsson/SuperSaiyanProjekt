using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<TimeReport>? TimeReps { get; set; }
    }
}