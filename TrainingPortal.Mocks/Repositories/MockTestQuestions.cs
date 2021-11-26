using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockTestQuestions : MockRepository<TestQuestion>
    {
        public List<TestQuestion> List
        {
            get => new()
            {
                new TestQuestion(1, "First question", new() { new("First answer"), new("Second answer") }),
                new TestQuestion(2, "Second question", new() { new("First answer"), new("Second answer"), new("Third answer") }),
                new TestQuestion(3, "Third question", new() { new("First answer"), new("Second answer"), new("Third answer"), new("Fourth answer") }),
                new TestQuestion(4, "Fourth question", new() { new("First answer"), new("Second answer") }),
                new TestQuestion(5, "Fifth question", new() { new("First answer"), new("Second answer"), new("Third answer") }),
                new TestQuestion(6, "Sixth question", new() { new("First answer"), new("Second answer"), new("Third answer") }),
                new TestQuestion(7, "Seventh question", new() { new("First answer"), new("Second answer"), new("Third answer"), new("Fourth answer"), new("Fifth answer") }),
            };
            set => throw new System.NotImplementedException();
        }
    }
}