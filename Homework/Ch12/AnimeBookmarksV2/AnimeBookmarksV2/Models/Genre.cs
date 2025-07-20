using System.ComponentModel.DataAnnotations;

namespace AnimeBookmarksV2.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Genre name is required")]
        public string Name { get; set; }

        public ICollection<AnimeGenre> AnimeGenres { get; set; } = new List<AnimeGenre>();
    }
}
