using System.ComponentModel.DataAnnotations;

namespace QuarterlySalers.Models
{
    public class HireDateValidation : ValidationAttribute
    {
        private readonly DateTime _companyStartDate = new DateTime(1995, 1, 1);

        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }

            if(value is DateTime date)
            {
                return date >= _companyStartDate;
            }

            return false;
        }
    }
}
