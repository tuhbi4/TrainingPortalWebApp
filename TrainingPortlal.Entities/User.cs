using TrainingPortal.Enums;

namespace TrainingPortal.Entities
{
    public class User
    {
        public int Id { get; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }

        public Roles Role { get; private set; }

        public string Lastname { get; private set; }

        public string Firstname { get; private set; }

        public string Patronymic { get; private set; }

        public User(int id, string login, string password, string email, Roles role, string lastname, string firstname, string patronymic)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            Role = role;
            Lastname = lastname;
            Firstname = firstname;
            Patronymic = patronymic;
        }

        public void UpdateLogin(string login)
        {
            Login = login;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateRole(Roles role)
        {
            Role = role;
        }

        public void UpdateLastname(string lastname)
        {
            Lastname = lastname;
        }

        public void UpdateFirstname(string firstname)
        {
            Firstname = firstname;
        }

        public void UpdatePatronymic(string patronymic)
        {
            Patronymic = patronymic;
        }
    }
}