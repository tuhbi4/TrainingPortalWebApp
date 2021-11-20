using System.Collections.Generic;
using TrainingPortal.Enums;

namespace TrainingPortal.Entities
{
    public class Course
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public List<Lesson> LessonsList { get; set; }

        public Test Test { get; set; }

        public Certificate Certificate { get; set; }

        public List<TargetAudiencies> TargetAudienciesList { get; set; }

        // UNDONE: Download certificate (in *.pdf) - add implementation
        public void DownloadCertificate() => throw new System.NotSupportedException();
    }
}