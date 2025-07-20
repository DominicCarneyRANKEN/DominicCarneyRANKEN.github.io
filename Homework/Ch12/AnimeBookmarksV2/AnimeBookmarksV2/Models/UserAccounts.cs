using System.ComponentModel.DataAnnotations;

namespace AnimeBookmarksV2.Models
{
    public class UserAccounts 
    {
        [Key]
        public int AccountId { get; set; }


        [Required(ErrorMessage = "A Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "An Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        public string? Password { get; set; }
        public string Role { get; set; } = "User";
        public List<UserBookmarks> Bookmarks { get; set; }
    }
}
