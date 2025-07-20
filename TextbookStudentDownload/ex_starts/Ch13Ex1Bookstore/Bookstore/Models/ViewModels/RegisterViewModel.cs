using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "A username is required")]
        [StringLength(255)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "A password is required")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Password must be the same")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;


    }
}
