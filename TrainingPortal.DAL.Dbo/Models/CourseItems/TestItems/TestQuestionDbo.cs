namespace TrainingPortal.DAL.Dbo.CourseItems.TestItems
{
    public class TestQuestionDbo
    {
        public int Id { get; }

        public int TestId { get; }

        public string Question { get; }

        public TestQuestionDbo(int id, int testId, string question)
        {
            Id = id;
            TestId = testId;
            Question = question;
        }
    }
}