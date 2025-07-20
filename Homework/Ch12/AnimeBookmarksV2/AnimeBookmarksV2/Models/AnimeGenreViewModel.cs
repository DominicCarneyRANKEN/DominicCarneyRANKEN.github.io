namespace AnimeBookmarksV2.Models
{
    public class AnimeGenreViewModel
    {
        public List<Animev2> Animesv2 { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public int SelectedGenreId { get; set; }
        
        public int TotalItems { get; set; }
        
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string SearchTerm { get; set; }

        public List<string> Genre { get; set; }

        public string SelectedGenre { get; set; }
        
        public string SearchString { get; set; }

        public int TotalPages { get; set; }

    }
}
