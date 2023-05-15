using System.ComponentModel.DataAnnotations;
using Models;

namespace SuperSaiyanProjekt.Dtos
{
    public class EmployeeDto
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
    }
}