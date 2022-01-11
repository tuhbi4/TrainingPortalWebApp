namespace TrainingPortal.DAL.Dbo.Models
{
    public class UserDbo
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Patronymic { get; set; }

        public UserDbo()
        { }

        public UserDbo(int id, string login, string passwordHash, string email, int roleId, string lastname, string firstname, string patronymic)
        {
            Id = id;
            Login = login;
            Password = passwordHash;
            Email = email;
            RoleId = roleId;
            Lastname = lastname;
            Firstname = firstname;
            Patronymic = patronymic;
        }
    }
}