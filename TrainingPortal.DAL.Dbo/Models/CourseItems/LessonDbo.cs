namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class LessonDbo
    {
        public int Id { get; }

        public string Name { get; }

        public string Material { get; }

        public LessonDbo(int id, string name, string material)
        {
            Id = id;
            Name = name;
            Material = material;
        }
    }
}