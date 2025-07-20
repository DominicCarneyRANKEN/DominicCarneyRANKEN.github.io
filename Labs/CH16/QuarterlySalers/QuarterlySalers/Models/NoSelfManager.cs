using System.ComponentModel.DataAnnotations;

namespace QuarterlySalers.Models
{
    public class NoSelfManager : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is Employee employ)
            {
                return employ.ManagerId != employ.ManagerId;
            }
            return false;
        }
    }
}
