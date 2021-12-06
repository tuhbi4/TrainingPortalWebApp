namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class TargetAudienceDbo
    {
        public int Id { get; }

        public string Name { get; }

        public TargetAudienceDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}