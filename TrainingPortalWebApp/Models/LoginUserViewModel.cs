using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models
{
    public class LoginUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}