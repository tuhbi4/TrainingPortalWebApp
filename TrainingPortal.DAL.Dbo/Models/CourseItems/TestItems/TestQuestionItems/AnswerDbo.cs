namespace TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems
{
    public class AnswerDbo
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsRightAnswer { get; set; }
    }
}