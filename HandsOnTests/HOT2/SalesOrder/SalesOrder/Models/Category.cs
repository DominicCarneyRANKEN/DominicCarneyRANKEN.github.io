using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        public string? CategoryName { get; set; }

        public List<Product>? Products { get; set; }
    }
}
