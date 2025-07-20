using System.ComponentModel.DataAnnotations;

namespace Project_3_1.Models
{
    public class Discount
    {

        [Required(ErrorMessage = "Subtotal is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal must be greater than 0.")]


  
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Discount percent is required.")]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100")]
        public int Percentage { get; set; }



        public decimal DiscountAmount => Subtotal * (Percentage / 100m);
        public decimal Total => Subtotal - DiscountAmount;



    }
}
