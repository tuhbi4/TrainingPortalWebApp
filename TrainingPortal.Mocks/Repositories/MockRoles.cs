using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public partial class MockRoles : MockRepository<Role>
    {
        public List<Role> List
        {
            get => new()
            {
                new Role(1, "Guest"),
                new Role(2, "User"),
                new Role(3, "Editor"),
                new Role(4, "Admin"),
            };
            set => throw new System.NotImplementedException();
        }
    }
}