namespace TrainingPortal.DAL.Dbo.Models
{
    public class CategoryDbo
    {
        public int Id { get; }

        public string Name { get; }

        public CategoryDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}