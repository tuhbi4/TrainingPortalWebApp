using System.Collections.Generic;

namespace TrainingPortal.Entities
{
    public class Test
    {
        public int Id { get; }

        public string Name { get; private set; }

        public List<TestQuestion> QuestionsList { get; private set; }

        public Test(int id, string name, List<TestQuestion> questionsList)
        {
            Id = id;
            Name = name;
            QuestionsList = questionsList;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateQuestions(List<TestQuestion> questionsList)
        {
            QuestionsList = questionsList;
        }
    }
}