using System.Collections.Generic;
using TrainingPortal.Enums;

namespace TrainingPortal.Entities
{
    public class Course
    {
        public int Id { get; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Category Category { get; private set; }

        public List<Lesson> LessonsList { get; private set; }

        public Test Test { get; private set; }

        public Certificate Certificate { get; private set; }

        public List<TargetAudiencies> TargetAudienciesList { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateCategory(Category category)
        {
            Category = category;
        }

        public void UpdateLessonsList(List<Lesson> lessonsList)
        {
            LessonsList = lessonsList;
        }

        public void UpdateTest(Test test)
        {
            Test = test;
        }

        public void UpdateCertificate(Certificate certificate)
        {
            Certificate = certificate;
        }

        public void UpdateTargetAudienciesList(List<TargetAudiencies> targetAudienciesList)
        {
            TargetAudienciesList = targetAudienciesList;
        }

        // UNDONE: Download certificate (in *.pdf) - add implementation
        public void DownloadCertificate() => throw new System.NotSupportedException();
    }
}