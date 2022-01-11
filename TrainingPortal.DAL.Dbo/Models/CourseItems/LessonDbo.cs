namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class LessonDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Material { get; set; }

        public LessonDbo()
        { }

        public LessonDbo(int id, string name, string material)
        {
            Id = id;
            Name = name;
            Material = material;
        }
    }
}