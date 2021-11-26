namespace TrainingPortal.Entities
{
    public class TargetAudience
    {
        public int Id { get; }

        public string Name { get; private set; }

        public TargetAudience(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}