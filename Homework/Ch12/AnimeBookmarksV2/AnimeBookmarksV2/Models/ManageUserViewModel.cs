using Microsoft.AspNetCore.Identity;

namespace AnimeBookmarksV2.Models
{
    public class ManageUserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAdmin => Role == "Admin";

        public string Role { get; set; } = "User";
    }
}
