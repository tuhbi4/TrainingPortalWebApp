using System.Collections.Generic;
using TrainingPortal.Entities.Models.CourseItems.TestItems.TestQuestionItems;

namespace TrainingPortal.Entities.Models.CourseItems.TestItems
{
    public class TestQuestion
    {
        public int Id { get; }

        public string Question { get; private set; }

        public List<Answer> Answers { get; private set; }

        public TestQuestion(int id, string question, List<Answer> answers)
        {
            Id = id;
            Question = question;
            Answers = answers;
        }

        public void UpdateQuestion(string question)
        {
            Question = question;
        }

        public void UpdateAnswers(List<Answer> answersList)
        {
            Answers = answersList;
        }
    }
}