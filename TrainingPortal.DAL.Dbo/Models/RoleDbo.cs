namespace TrainingPortal.DAL.Dbo.Models
{
    public class RoleDbo
    {
        public int Id { get; }

        public string Name { get; }

        public RoleDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}