using System;
using System.ComponentModel.DataAnnotations;

namespace Customer_Validation.CustomValidations
{
    public class ValidJoiningDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !DateTime.TryParse(value.ToString(), out DateTime doj))
                return new ValidationResult("Invalid or missing date of joining.");

            if (doj <= DateTime.Today)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "Date of joining cannot be in the future.");
        }
    }
}
