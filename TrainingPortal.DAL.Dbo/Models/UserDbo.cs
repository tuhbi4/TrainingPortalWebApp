namespace TrainingPortal.DAL.Dbo.Models
{
    public class UserDbo
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Patronymic { get; set; }
    }
}