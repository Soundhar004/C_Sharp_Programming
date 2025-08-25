using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coding_CC9.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // Action 1: Customers in Germany
        public ActionResult CustomersInGermany()
        {
            var germanCustomers = db.Customers
                                    .Where(c => c.Country == "Germany")
                                    .ToList();
            return View(germanCustomers);
        }

        // Action 2: Customer details for OrderID = 10248
        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();
            return View(customer);
        }
    }

}