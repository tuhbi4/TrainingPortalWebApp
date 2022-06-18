using System.Collections.Generic;
using TrainingPortal.BLL.Models.CourseItems;

namespace TrainingPortal.BLL.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public List<Lesson> LessonsList { get; set; }

        public Test Test { get; set; }

        public Certificate Certificate { get; set; }

        public List<TargetAudience> TargetAudienciesList { get; set; }
    }
}