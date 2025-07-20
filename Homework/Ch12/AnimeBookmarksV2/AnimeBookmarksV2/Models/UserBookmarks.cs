namespace AnimeBookmarksV2.Models
{
    public class UserBookmarks
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public UserAccounts User { get; set; }

        public int AnimeId { get; set; }

        public Animev2 Anime { get; set; }
        
    }
}
