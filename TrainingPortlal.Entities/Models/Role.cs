namespace TrainingPortal.Entities.Models
{
    public class Role
    {
        public int Id { get; }

        public string Name { get; private set; }

        public Role(int id, string name)
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