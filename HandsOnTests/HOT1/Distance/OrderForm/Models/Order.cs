using System.ComponentModel.DataAnnotations;

namespace OrderForm.Models
{
    public class Order
    {
        [Required(ErrorMessage = "A quantity is required sir/ma'am.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity shall not contain 0 PARTNER" )]
        public int? Quantity { get; set; }

        public string? Discount { get; set; }
    }
}
