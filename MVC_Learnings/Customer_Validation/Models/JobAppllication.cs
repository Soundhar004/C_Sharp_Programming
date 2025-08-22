using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Customer_Validation.CustomValidations;

namespace Customer_Validation.Models
{
    public class JobApplication
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Applicant Name")]
        public string Name { get; set; }  // ✅ Removed recursive 'name' property

        [Display(Name = "Years of Experience")]
        [Range(3, 10, ErrorMessage = "Experience must be between 3 and 10 years")]
        public int Experience { get; set; }  // ✅ PascalCase

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [ValidBirthDate(ErrorMessage = "DOB should be between 01/01/1996 and 31/12/2003 only")]
        public DateTime BirthDate { get; set; }  // ✅ PascalCase

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email ID")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})$",
            ErrorMessage = "Invalid email format")]
        public string Email { get; set; }  // ✅ PascalCase

        [GenderValidate(ErrorMessage = "Please select your correct gender")]
        public string Gender { get; set; }

        [Display(Name = "Expected Salary")]
        [RegularExpression(@"^(0(?!\.00)|[1-9]\d{0,6})\.\d{2}$",
            ErrorMessage = "Salary should be like 6000.45")]
        public decimal ExpectedSalary { get; set; }  // ✅ PascalCase

        [SkillValidation(ErrorMessage = "Select at least 3 skills")]
        public List<CheckBox> Skills { get; set; }

        [Required(ErrorMessage = "Passport status is required")]
        [Display(Name = "Do you have a passport?")]
        public string HavePassport { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [ValidPasswordFormat(ErrorMessage = "Password must start with uppercase, followed by a digit, then 5 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public JobApplication()
        {
            Skills = new List<CheckBox>
            {
                new CheckBox { SkillName = "CSharp" },
                new CheckBox { SkillName = "MS SQL" },
                new CheckBox { SkillName = "ADO.Net" },
                new CheckBox { SkillName = "Web Technologies" },
                new CheckBox { SkillName = "MVC" }
            };
        }
    }
}
