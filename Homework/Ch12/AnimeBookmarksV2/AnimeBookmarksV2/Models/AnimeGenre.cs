using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeBookmarksV2.Models
{
    public class AnimeGenre
    {
        [Key, Column(Order = 0)]
        public int AnimeId { get; set; }

        public Animev2 Anime { get; set; } = null!;

        [Key, Column(Order = 1)]
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
