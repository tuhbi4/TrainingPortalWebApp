using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models
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