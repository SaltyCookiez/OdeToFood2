using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
    }
}