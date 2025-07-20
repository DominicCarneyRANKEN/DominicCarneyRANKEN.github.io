using System.ComponentModel.DataAnnotations;

namespace AnimeBookmarksV2.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passowrd is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
