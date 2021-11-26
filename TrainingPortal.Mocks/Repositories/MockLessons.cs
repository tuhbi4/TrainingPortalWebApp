using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockLessons : MockRepository<Lesson>
    {
        public List<Lesson> List
        {
            get => new()
            {
                new Lesson(1, "First lesson", "Additional materials"),
                new Lesson(2, "Second lesson", "Additional materials"),
                new Lesson(3, "Third lesson", "Additional materials"),
                new Lesson(4, "Fourth lesson", "Additional materials"),
                new Lesson(5, "Fifth lesson", "Additional materials"),
            };
            set => throw new System.NotImplementedException();
        }
    }
}