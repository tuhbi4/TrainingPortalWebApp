using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockCourses
    {
        public List<Course> CoursesList { get; set; } = new List<Course>()
        {
            new Course(1, "Layout design", "Course description", mockCategories.CategoriesList[0],
                new(){ mockLessons.LessonsList[0], mockLessons.LessonsList[1], mockLessons.LessonsList[2] },
                mockTests.TestsList[0], mockCertificates.CertificatesList[0],
                new(){ mockTargetAudiences.TargetAudiencesList[0], mockTargetAudiences.TargetAudiencesList[1]}),
            new Course(1, "ASP.NET", "Course description", mockCategories.CategoriesList[0],
                new(){ mockLessons.LessonsList[0], mockLessons.LessonsList[1], mockLessons.LessonsList[2] },
                mockTests.TestsList[0], mockCertificates.CertificatesList[1],
                new(){ mockTargetAudiences.TargetAudiencesList[1], mockTargetAudiences.TargetAudiencesList[2]}),
            new Course(1, "Frontend", "Course description", mockCategories.CategoriesList[0],
                new(){ mockLessons.LessonsList[0], mockLessons.LessonsList[1], mockLessons.LessonsList[2] },
                mockTests.TestsList[0], mockCertificates.CertificatesList[2],
                new(){ mockTargetAudiences.TargetAudiencesList[2]}),
            new Course(1, "Python", "Course description", mockCategories.CategoriesList[0],
                new(){ mockLessons.LessonsList[0], mockLessons.LessonsList[1], mockLessons.LessonsList[2] },
                mockTests.TestsList[0], mockCertificates.CertificatesList[3],
                new(){ mockTargetAudiences.TargetAudiencesList[1]}),
            new Course(1, "PHP", "Course description", mockCategories.CategoriesList[0],
                new(){ mockLessons.LessonsList[0], mockLessons.LessonsList[1], mockLessons.LessonsList[2] },
                mockTests.TestsList[0], mockCertificates.CertificatesList[4],
                new(){ mockTargetAudiences.TargetAudiencesList[0]}),
        };

        private static readonly MockCategories mockCategories = new();
        private static readonly MockLessons mockLessons = new();
        private static readonly MockTests mockTests = new();
        private static readonly MockCertificates mockCertificates = new();
        private static readonly MockTargetAudiences mockTargetAudiences = new();
    }
}