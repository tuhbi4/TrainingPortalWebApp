namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class TestDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TestDbo()
        { }

        public TestDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}