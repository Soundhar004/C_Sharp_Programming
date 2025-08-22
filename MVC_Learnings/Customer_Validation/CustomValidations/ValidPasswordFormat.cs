using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Customer_Validation.CustomValidations
{
    public class ValidPasswordFormat : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = Convert.ToString(value)?.Trim();

            if (string.IsNullOrEmpty(password))
                return new ValidationResult("Password is required.");

            if (password.Length != 7)
                return new ValidationResult("Password must be exactly 7 characters long.");

            if (!char.IsUpper(password[0]))
                return new ValidationResult("Password must start with an uppercase letter.");

            if (!char.IsDigit(password[1]))
                return new ValidationResult("Second character must be a digit.");

            string tail = password.Substring(2);
            if (tail.Contains(" "))
                return new ValidationResult("Password must not contain spaces.");

            bool hasSpecialChar = false;
            foreach (char c in tail)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialChar = true;
                    break;
                }
            }

            if (!hasSpecialChar)
                return new ValidationResult("Password must include at least one special character.");

            return ValidationResult.Success;
        }



    }
}
