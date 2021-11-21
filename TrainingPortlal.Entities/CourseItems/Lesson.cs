namespace TrainingPortal.Entities
{
    public class Lesson
    {
        public int Id { get; }

        public string Name { get; private set; }

        // UNDONE: Lesson material - think over the type (maby that will *.html files or something else)
        public object Material { get; private set; }

        public Lesson(int id, string name, object material)
        {
            Id = id;
            Name = name;
            Material = material;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateMaterial(object material)
        {
            Material = material;
        }
    }
}