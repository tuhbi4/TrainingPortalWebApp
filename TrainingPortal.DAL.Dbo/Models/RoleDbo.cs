namespace TrainingPortal.DAL.Dbo.Models
{
    public class RoleDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleDbo()
        { }

        public RoleDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}