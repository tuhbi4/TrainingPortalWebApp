using System.Collections.Generic;

namespace TrainingPortal.Entities
{
    public class TestQuestion
    {
        public int Id { get; }

        public string Question { get; private set; }

        public List<string> Answers { get; private set; }

        public TestQuestion(int id, string question, List<string> answers)
        {
            Id = id;
            Question = question;
            Answers = answers;
        }

        public void UpdateQuestion(string question)
        {
            Question = question;
        }

        public void UpdateAnswers(List<string> answers)
        {
            Answers = answers;
        }
    }
}