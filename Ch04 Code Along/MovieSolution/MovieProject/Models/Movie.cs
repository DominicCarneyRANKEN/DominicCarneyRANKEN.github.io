using System.ComponentModel.DataAnnotations;

namespace MovieProject.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a name" )]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year ")]
        [Range(1900, 2024, ErrorMessage = "Year must be between 1900 and 2024")]

        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 2 and 5")]
        public int Rating { get; set; }
    }
}
