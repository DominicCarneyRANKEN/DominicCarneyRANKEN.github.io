using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace QuarterlySalers.Models
{
    public class Employee
    {
        [Key]
        public int EmployId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage = "Date of birth must be in the past")]

        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Date of hire is required")]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage = "Date of hire must be in the past.")]
        [HireDateValidation(ErrorMessage = "Date of hire mustn't be before 1/1/1995")]
        public DateTime DateOfHire { get; set; }

        public int? ManagerId { get; set; }

        public ICollection<Sales>? Sale { get; set; }
    }
}
