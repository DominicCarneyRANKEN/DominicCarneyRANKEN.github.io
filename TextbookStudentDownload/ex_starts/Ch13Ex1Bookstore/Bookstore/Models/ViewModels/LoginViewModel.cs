using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "A username is required before logging in")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "A password is required before logging in")]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
