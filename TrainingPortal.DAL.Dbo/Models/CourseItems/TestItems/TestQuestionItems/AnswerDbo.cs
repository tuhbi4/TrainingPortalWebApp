namespace TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems
{
    public class AnswerDbo
    {
        public int Id { get; }

        public int QuestionId { get; private set; }

        public string Text { get; }

        public AnswerDbo(int id, int questionId, string text)
        {
            Id = id;
            QuestionId = questionId;
            Text = text;
        }

        public void UpdateQuestionId(int id)
        {
            QuestionId = id;
        }
    }
}