using System.ComponentModel.DataAnnotations;

namespace EFCommands.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
