using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.WebPL.Models
{
    public class CategoryViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}