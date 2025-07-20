using System.ComponentModel.DataAnnotations;

namespace Project_2_2.Models
{
    public class Calculator
    {
       
        [Required(ErrorMessage = "Meal cost is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Meal cost must be greater than 0.")]
       
        public decimal MealCost { get; set; }

   
        public decimal Tip15Percent => MealCost * 0.15m;
        public decimal Tip20Percent => MealCost * 0.20m;
        public decimal Tip25Percent => MealCost * 0.25m;
    }
}
