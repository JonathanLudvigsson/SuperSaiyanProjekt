using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TimeReport
    {
        [Key]
        public int RepoId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int WeekNumber { get; set; }
        public int HoursWorked { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Project? Project { get; set; }
    }
}
