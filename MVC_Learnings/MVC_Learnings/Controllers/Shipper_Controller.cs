/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Learnings.Models;

namespace MVC_Learnings.Controllers
{
    public class Shipper_Controller : Controller
    {

        NorthwindEntities db = new NorthwindEntities();
        // GET: Shipper
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            Shipper s = new Shipper();
            s.ShipperID = Convert.ToInt32(Request["ShipperID"]);
            s.CompanyName = Request["CompanyName"].ToString();
            s.Phone = Request["Phone"].ToString();

            db.Shippers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //4. Stored procedure calling
        public ActionResult Sp_With_Parameter()
        {
            return View(db.CustOrdersOrders("Alfki"));
        }
    }
}*/