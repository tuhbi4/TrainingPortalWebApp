using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [DataType(DataType.Text)]
        public string Patronymic { get; set; }
    }
}