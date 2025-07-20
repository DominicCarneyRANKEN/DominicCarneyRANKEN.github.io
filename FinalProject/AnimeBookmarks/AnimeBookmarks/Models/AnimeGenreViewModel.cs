using System.Collections.Generic;
using AnimeBookmarks.Models;

namespace AnimeBookmarks.Models
{
    public class AnimeGenreViewModel
    {
        public List<Anime> Animes { get; set; }
        public List<string> Genres { get; set; }
        public string SelectedGenre { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}
