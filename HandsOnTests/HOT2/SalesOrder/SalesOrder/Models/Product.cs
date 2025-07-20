using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string? ProductName { get; set; }

        public string? Slug { get; set; }

        [Required(ErrorMessage = "Product Image URL is required.")]
        public string? ProductImage { get; set; }

        public string ProductDescShort { get; set; } = "";  
        public string ProductDescLong { get; set; } = "";  

        [Range(1, 100000, ErrorMessage = "Price must be between $1 and $100,000.")]
        public decimal ProductPrice { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int ProductQty { get; set; }

        public int CategoryID { get; set; } 

        public Category? Category { get; set; }  



        
    }
}

