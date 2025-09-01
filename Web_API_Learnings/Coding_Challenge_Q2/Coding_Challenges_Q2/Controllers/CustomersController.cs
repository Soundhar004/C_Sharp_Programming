using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Coding_Challenges_Q2.Models;

namespace Coding_Challenges_Q2.Controllers
{
    public class CustomersController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET api/customers/bycountry?country=?
        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var countryParam = new SqlParameter("@Country", country);
            var customers = db.Database
                .SqlQuery<Customer>("EXEC GetCustomersByCountry @Country", countryParam)
                .ToList();
            return Ok(customers);
        }
    }
}
