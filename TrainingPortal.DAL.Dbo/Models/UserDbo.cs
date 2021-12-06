namespace TrainingPortal.DAL.Dbo.Models
{
    public class UserDbo
    {
        public int Id { get; }

        public string Login { get; }

        public string PasswordHash { get; }

        public string Email { get; }

        public int RoleId { get; }

        public string Lastname { get; }

        public string Firstname { get; }

        public string Patronymic { get; }

        public UserDbo(int id, string login, string passwordHash, string email, int roleId, string lastname, string firstname, string patronymic)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            Email = email;
            RoleId = roleId;
            Lastname = lastname;
            Firstname = firstname;
            Patronymic = patronymic;
        }
    }
}