using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var member = (Member)validationContext.ObjectInstance;

            // Kontrollera om FirstName och LastName är samma
            if (member.FirstName.ToUpper() == member.LastName.ToUpper())
            {
                return new ValidationResult("First Name and Last Name cannot be the same.");
            }

            return ValidationResult.Success;
        }
    }
}
