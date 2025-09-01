using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Coding_Challenge_10_Q1.Models;
using Coding_Challenge_10_Q1.Data;

namespace Coding_Challenge_10_Q1.Controllers
{
    [RoutePrefix("api/country")]
    public class CountryApiController : ApiController
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: api/country
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var countries = db.Countries.ToList();
            return Ok(countries); // Returns empty list if none found
        }

        // GET: api/country/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var country = db.Countries.Find(id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        // POST: api/country
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] Country country)
        {
            if (country == null)
            {
                var rawBody = Request.Content.ReadAsStringAsync().Result;
                return BadRequest("Country data is missing or malformed. Raw body: " + rawBody);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return Ok(country); // Changed from CreatedAtRoute for simplicity
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/country/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Country data is missing.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = db.Countries.Find(id);
            if (existing == null)
                return NotFound();

            try
            {
                existing.CountryName = country.CountryName;
                existing.Capital = country.Capital;
                db.SaveChanges();
                return Ok(existing);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/country/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null)
                return NotFound();

            try
            {
                db.Countries.Remove(country);
                db.SaveChanges();
                return Ok($"Country with ID {id} deleted.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
