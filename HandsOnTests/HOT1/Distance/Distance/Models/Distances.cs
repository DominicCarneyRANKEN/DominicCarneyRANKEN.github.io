using System.ComponentModel.DataAnnotations;

namespace Distance.Models
{
    public class Distances
    {
        [Required(ErrorMessage = "Error, must be a Distance")]
        [Range(1, 500, ErrorMessage = "Oops, distance shall only be 1 and 500 sir/ma'am.")]

        public double? Inches { get; set; }

        public double Centimeters => (Inches ?? 0) * 2.54;

        
        public string FormattedInches => Inches?.ToString("F2") ?? "0.00";
        public string FormattedCentimeters => Centimeters.ToString("F2");
    }
}

