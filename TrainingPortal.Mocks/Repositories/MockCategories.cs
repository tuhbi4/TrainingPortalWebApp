using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockCategories : MockRepository<Category>
    {
        public List<Category> List
        {
            get => new()
            {
                new Category(1, "Layout designer"),
                new Category(2, "ASP.NET Developer"),
                new Category(3, "Frontend Developer"),
                new Category(4, "Python Developer"),
                new Category(5, "PHP Developer"),
            };
            set => throw new System.NotImplementedException();
        }
    }
}