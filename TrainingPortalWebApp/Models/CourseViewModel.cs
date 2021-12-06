using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models
{
    public class CourseViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}