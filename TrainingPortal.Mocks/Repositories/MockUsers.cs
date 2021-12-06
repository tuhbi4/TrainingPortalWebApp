using System.Collections.Generic;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Mocks
{
    public class MockUsers : MockRepository<User>
    {
        public List<User> List
        {
            get => new()
            {
                new User(1, "guest", "guest", "guest@tp.com", mockRoles.List[0], "Guest lastname", "Guest firstname", "Guest patronymic"),
                new User(1, "user", "user", "user@tp.com", mockRoles.List[1], "Userlastname", "Userfirstname", "Userpatronymic"),
                new User(1, "editor", "editor", "editor@tp.com", mockRoles.List[2], "Editorlastname", "Editorfirstname", "Editorpatronymic"),
                new User(1, "admin", "admin", "admin@tp.com", mockRoles.List[3], "Adminlastname", "Adminfirstname", "Adminpatronymic"),
            };
            set => throw new System.NotImplementedException();
        }

        private static readonly MockRoles mockRoles = new();
    }
}