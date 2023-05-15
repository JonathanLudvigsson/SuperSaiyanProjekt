using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int WeekNumber { get; set; }
        public int HoursWorked { get; set; }

        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
        [JsonIgnore]
        public virtual Project? Project { get; set; }
    }
}
