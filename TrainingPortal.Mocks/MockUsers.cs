using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockUsers
    {
        public List<User> UsersList { get; set; } = new List<User>()
        {
                new User(1, "guest", "guest", "guest@tp.com", mockRoles.RolesList[0], "Guest lastname", "Guest firstname", "Guest patronymic"),
                new User(1, "user", "user", "user@tp.com", mockRoles.RolesList[1], "Userlastname", "Userfirstname", "Userpatronymic"),
                new User(1, "editor", "editor", "editor@tp.com", mockRoles.RolesList[2], "Editorlastname", "Editorfirstname", "Editorpatronymic"),
                new User(1, "admin", "admin", "admin@tp.com", mockRoles.RolesList[3], "Adminlastname", "Adminfirstname", "Adminpatronymic"),
        };

        private static readonly MockRoles mockRoles = new();
    }
}