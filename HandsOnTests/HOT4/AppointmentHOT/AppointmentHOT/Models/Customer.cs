using System.ComponentModel.DataAnnotations;

namespace AppointmentHOT.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Oops, please enter a username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Oopsie, please enter a phone number")]
        public string? Phonenumber { get; set; } 
    }
}
