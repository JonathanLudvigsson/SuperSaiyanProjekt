using System.ComponentModel.DataAnnotations;

namespace SuperSaiyanProjekt.Dtos
{
    public class TimeReportDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int WeekNumber { get; set; }
        [Required]
        public int HoursWorked { get; set; }
    }
}
