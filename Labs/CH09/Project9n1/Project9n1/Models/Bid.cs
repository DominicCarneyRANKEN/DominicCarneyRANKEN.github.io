using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Project9n1.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public double Price { get; set; }

        [Required]

        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]

        public IdentityUser? User { get; set; }

        public int? ListingId { get; set; }
        [ForeignKey("")]
        public Listing? Listing { get; set; }
    }
}
