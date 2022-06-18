using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models.User
{
    public class SettingsUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [DataType(DataType.Text)]
        public string Patronymic { get; set; }
    }
}