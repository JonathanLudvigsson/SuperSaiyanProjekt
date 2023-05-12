using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<TimeReport>? TimeReports { get; set; } = new List<TimeReport>();
        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
