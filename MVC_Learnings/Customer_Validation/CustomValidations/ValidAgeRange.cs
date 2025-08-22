using System;
using System.ComponentModel.DataAnnotations;

namespace Customer_Validation.CustomValidations
{
    public class ValidAgeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !DateTime.TryParse(value.ToString(), out DateTime dob))
                return new ValidationResult("Invalid or missing date of birth.");

            int age = DateTime.Today.Year - dob.Year;
            if (dob > DateTime.Today.AddYears(-age)) age--;

            if (age >= 21 && age <= 25)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "Age must be between 21 and 25 years.");
        }
    }
}
