using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Customer_Validation.CustomValidations;

namespace Customer_Validation.Models
{
    public class CheckBox
    {
        public bool IsChecked { get; set; }


        /*[ValidAgeRange(ErrorMessage = "Candidate must be between 21 and 25 years.")]
        public DateTime DOB { get; set; }

        [ValidJoiningDate(ErrorMessage = "Joining date cannot be in the future.")]
        public DateTime DOJ { get; set; }

        [ValidPasswordFormat(ErrorMessage = "Password must start with uppercase, followed by a digit, then 5 characters.")]
        public string Password { get; set; }*/
        public string SkillName { get; set; }

    }
}