using System.Collections.Generic;
using TrainingPortal.Entities.Models.CourseItems.TestItems;

namespace TrainingPortal.DAL.Mocks
{
    public class MockTestQuestions : MockRepository<TestQuestion>
    {
        public List<TestQuestion> List
        {
            get => new()
            {
                new TestQuestion(1, "First question", new()
                {
                    new(1, "First answer"),
                    new(2, "Second answer")
                }),
                new TestQuestion(2, "Second question", new()
                {
                    new(3, "First answer"),
                    new(4, "Second answer"),
                    new(5, "Third answer")
                }),
                new TestQuestion(3, "Third question", new()
                {
                    new(6, "First answer"),
                    new(7, "Second answer"),
                    new(8, "Third answer"),
                    new(9, "Fourth answer")
                }),
                new TestQuestion(4, "Fourth question", new()
                {
                    new(10, "First answer"),
                    new(11, "Second answer")
                }),
                new TestQuestion(5, "Fifth question", new()
                {
                    new(12, "First answer"),
                    new(13, "Second answer"),
                    new(14, "Third answer")
                }),
                new TestQuestion(6, "Sixth question", new()
                {
                    new(15, "First answer"),
                    new(16, "Second answer"),
                    new(17, "Third answer")
                }),
                new TestQuestion(7, "Seventh question", new()
                {
                    new(18, "First answer"),
                    new(19, "Second answer"),
                    new(20, "Third answer"),
                    new(21, "Fourth answer"),
                    new(22, "Fifth answer")
                }),
            };
            set => throw new System.NotImplementedException();
        }
    }
}