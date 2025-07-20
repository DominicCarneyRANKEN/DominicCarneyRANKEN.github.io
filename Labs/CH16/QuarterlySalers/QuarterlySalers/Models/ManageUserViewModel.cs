using Microsoft.AspNetCore.Identity;

namespace QuarterlySalers.Models
{
    public class ManageUserViewModel
    {

        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public bool IsAdmin => Role == "Admin";

        public string Role { get; set; } = "User";
    }
}
