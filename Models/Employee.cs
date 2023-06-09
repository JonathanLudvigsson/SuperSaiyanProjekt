﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public virtual ICollection<Project>? Projects { get; set; } = new List<Project>();
        [JsonIgnore]
        public virtual ICollection<TimeReport>? TimeReps { get; set; } = new List<TimeReport>();
    }
}