using System.Collections.Generic;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Mocks
{
    public class MockCourses : MockRepository<Course>
    {
        public List<Course> List
        {
            get => new()
            {
                new Course(1, "Layout designer", "Course description", mockCategories.List[0],
                new() { mockLessons.List[0], mockLessons.List[1], mockLessons.List[2] },
                mockTests.List[0], mockCertificates.List[0],
                new() { mockTargetAudiences.List[0], mockTargetAudiences.List[1] }),
                new Course(2, "ASP.NET Developer", "Course description", mockCategories.List[1],
                new() { mockLessons.List[0], mockLessons.List[1], mockLessons.List[2] },
                mockTests.List[1], mockCertificates.List[1],
                new() { mockTargetAudiences.List[1], mockTargetAudiences.List[2] }),
                new Course(3, "Frontend Developer", "Course description", mockCategories.List[2],
                new() { mockLessons.List[0], mockLessons.List[1], mockLessons.List[2] },
                mockTests.List[2], mockCertificates.List[2],
                new() { mockTargetAudiences.List[2] }),
                new Course(4, "Python Developer", "Course description", mockCategories.List[3],
                new() { mockLessons.List[0], mockLessons.List[1], mockLessons.List[2] },
                mockTests.List[3], mockCertificates.List[3],
                new() { mockTargetAudiences.List[1] }),
                new Course(5, "PHP Developer", "Course description", mockCategories.List[4],
                new() { mockLessons.List[0], mockLessons.List[1], mockLessons.List[2] },
                mockTests.List[4], mockCertificates.List[4],
                new() { mockTargetAudiences.List[0] }),
            };
            set => throw new System.NotImplementedException();
        }

        private static readonly MockCategories mockCategories = new();
        private static readonly MockLessons mockLessons = new();
        private static readonly MockTests mockTests = new();
        private static readonly MockCertificates mockCertificates = new();
        private static readonly MockTargetAudiences mockTargetAudiences = new();
    }
}