namespace TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems
{
    public class AnswerDbo
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsRightAnswer { get; set; }

        public AnswerDbo()
        { }

        public AnswerDbo(int id, int questionId, string text, bool isRightAnswer)
        {
            Id = id;
            QuestionId = questionId;
            Text = text;
            IsRightAnswer = isRightAnswer;
        }
    }
}