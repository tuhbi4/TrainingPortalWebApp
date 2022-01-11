namespace TrainingPortal.DAL.Dbo.CourseItems.TestItems
{
    public class TestQuestionDbo
    {
        public int Id { get; set; }

        public int TestId { get; set; }

        public string Question { get; set; }

        public TestQuestionDbo()
        { }

        public TestQuestionDbo(int id, int testId, string question)
        {
            Id = id;
            TestId = testId;
            Question = question;
        }
    }
}