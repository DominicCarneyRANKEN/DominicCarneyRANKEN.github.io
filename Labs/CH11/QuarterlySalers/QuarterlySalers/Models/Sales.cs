using System.ComponentModel.DataAnnotations;

namespace QuarterlySalers.Models
{
    public class Sales
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public int EmployId { get; set; }

        public Employee? Employee { get; set; }

        [Required(ErrorMessage = "Quarter is required")]
        [Range(1, 4, ErrorMessage = "Quarter must be between 1 and 4.")]
        public int Quarter { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public double Amount { get; set; }
    }
}
