using TrainingPortal.Enums;

namespace TrainingPortal.Entities
{
    public class Category
    {
        public int Id { get; }

        public Categories Name { get; private set; }

        public Category(int id, Categories name)
        {
            Id = id;
            Name = name;
        }

        public void UpdateName(Categories name)
        {
            Name = name;
        }
    }
}