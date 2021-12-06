namespace TrainingPortal.Entities.Models.CourseItems
{
    public class Lesson
    {
        public int Id { get; }

        public string Name { get; private set; }

        public string Material { get; private set; }

        public Lesson(int id, string name, string material)
        {
            Id = id;
            Name = name;
            Material = material;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateMaterial(string material)
        {
            Material = material;
        }
    }
}