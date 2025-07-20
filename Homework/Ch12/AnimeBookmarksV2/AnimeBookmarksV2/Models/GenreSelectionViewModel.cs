namespace AnimeBookmarksV2.Models
{
    public class GenreSelectionViewModel
    {
        public int AnimeId { get; set; }
        public List<Genre> AllGenres { get; set; } = new List<Genre>();
        public List<int> SelectedGenreIds { get; set; } = new List<int>();

    }
}
