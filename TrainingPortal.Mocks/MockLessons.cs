using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.BLL.Mocks
{
    public class MockLessons
    {
        public List<Lesson> LessonsList { get; set; } = new List<Lesson>()
        {
            new Lesson(1, "First lesson", "Additional materials"),
            new Lesson(2, "Second lesson", "Additional materials"),
            new Lesson(3, "Third lesson", "Additional materials"),
            new Lesson(4, "Fourth lesson", "Additional materials"),
            new Lesson(5, "Fifth lesson", "Additional materials"),
        };
    }
}