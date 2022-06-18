using System.Collections.Generic;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Mocks
{
    public class MockCategories : MockRepository<Category>
    {
        public List<Category> List
        {
            get => new()
            {
                new Category(1, "Layout design"),
                new Category(2, "ASP.NET"),
                new Category(3, "Frontend"),
                new Category(4, "Python"),
                new Category(5, "PHP"),
            };
            set => throw new System.NotImplementedException();
        }
    }
}