using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer_Validation.Models;

namespace Customer_Validation.Controllers
{
    public class JobApllicationController : Controller
    {
        // GET: JobApllication
        public ActionResult Index()
        {
            var model = new JobApplication
            {
                Skills = GetSkillList()
            };

            return View(model);
        }

        // POST: JobApllication
        [HttpPost]
        public ActionResult Index(JobApplication JA)
        {
            // Always reassign skills to preserve checkbox list
            JA.Skills = GetSkillList();

            if (ModelState.IsValid)
            {
                ViewBag.Result = "Application Form Submitted Successfully";
            }
            else
            {
                ViewBag.Result = "Invalid Entries, Check and resubmit..";
            }

            return View(JA); // Return model to preserve input and show errors
        }

        // Helper method to populate skill list
        private List<CheckBox> GetSkillList()
        {
            return new List<CheckBox>
            {
                new CheckBox { SkillName = "C#" },
                new CheckBox { SkillName = "SQL" },
                new CheckBox { SkillName = "ASP.NET" },
                new CheckBox { SkillName = "MVC" },
                new CheckBox { SkillName = "JavaScript" },
                new CheckBox { SkillName = "HTML" }
            };
        }
    }
}
