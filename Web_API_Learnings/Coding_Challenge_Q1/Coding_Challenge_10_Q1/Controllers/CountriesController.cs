using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Coding_Challenge_10_Q1.Data;
using Coding_Challenge_10_Q1.Models;


namespace Coding_Challenge_10_Q1.Controllers
{
    public class CountriesController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: Countries
        public ActionResult Index()
        {
            var countries = db.Countries.ToList();
            return View(countries);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var country = db.Countries.Find(id);
            if (country == null)
                return HttpNotFound();
            return View(country);


        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryName,Capital")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Countries.Add(country);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the error (ex) here if needed
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var country = db.Countries.Find(id);
            if (country == null)
                return HttpNotFound();
            return View(country);

        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryName,Capital")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the error (ex) here if needed
                ModelState.AddModelError("", "Unable to update. Try again.");
            }

            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var country = db.Countries.Find(id);
            if (country == null)
                return HttpNotFound();
            return View(country);

        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var country = db.Countries.Find(id);
                if (country != null)
                {
                    db.Countries.Remove(country);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the error (ex) here if needed
                ModelState.AddModelError("", "Unable to delete. Try again.");
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
