namespace TrainingPortal.Entities.Models.CourseItems.TestItems.TestQuestionItems
{
    public class Answer
    {
        public int Id { get; }

        public string Text { get; private set; }

        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public void UpdateText(string text)
        {
            Text = text;
        }
    }
}