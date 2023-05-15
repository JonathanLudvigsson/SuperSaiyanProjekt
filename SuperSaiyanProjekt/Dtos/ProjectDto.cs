using System.ComponentModel.DataAnnotations;
using Models;

namespace SuperSaiyanProjekt.Dtos
{
    public class ProjectDto
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}