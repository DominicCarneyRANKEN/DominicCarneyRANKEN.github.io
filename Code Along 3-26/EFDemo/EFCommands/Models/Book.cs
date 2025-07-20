using System.ComponentModel.DataAnnotations;

namespace EFCommands.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public double Price { get; set; }

        public double? Discount { get; set; }
    }
}
