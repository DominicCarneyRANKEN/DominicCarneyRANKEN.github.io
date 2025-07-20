namespace AnimeBookmarksV2.Models
{
    public class EditAnimeViewModel
    {
        public Animev2 Anime { get; set; }
        public List<Genre> AllGenres { get; set; } = new List<Genre>();

        public List<int> SelectedGenreId { get; set; } = new List<int>();
    }
}
