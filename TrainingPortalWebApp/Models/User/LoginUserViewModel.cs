using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models.User
{
    public class LoginUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}