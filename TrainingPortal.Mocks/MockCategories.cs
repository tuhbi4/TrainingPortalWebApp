using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockCategories
    {
        public List<Category> CategoriesList { get; set; } = new List<Category>()
        {
            new Category(1, "Layout designer"),
            new Category(2, "ASP.NET Developer"),
            new Category(3, "Frontend Developer"),
            new Category(4, "Python Developer"),
            new Category(5, "PHP Developer"),
        };
    }
}