using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace AnimeBookmarksV2.Models
{
    public class Animev2
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "A Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You must provide an anime link to this anime")]
        public string? AnimeLink { get; set; }

        public string? ImagePath { get; set; }

        public int? GenreId { get; set; }

        public ICollection<AnimeGenre> AnimeGenres { get; set; } = new List<AnimeGenre>();

        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrEmpty(title))
                return string.Empty;

            string normalized = title.Normalize(NormalizationForm.FormD);
            var chars = normalized.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            string cleanTitle = new string(chars.ToArray()).Normalize(NormalizationForm.FormC);

            string slug = Regex.Replace(cleanTitle, @"[^a-zA-Z0-9]+", "-").Trim('-');

            return slug.ToLower();
        }
    }


}
