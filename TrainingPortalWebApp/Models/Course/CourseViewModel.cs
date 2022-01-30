using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Models.CourseItems;

namespace TrainingPortal.WebPL.Models.Course
{
    public class CourseViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public Category Category { get; set; }

        public List<Lesson> LessonsList { get; set; }

        [Required]
        public Test Test { get; set; }

        [Required]
        public Certificate Certificate { get; set; }

        public List<TargetAudience> TargetAudienciesList { get; set; }
    }
}