using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;



namespace InsuranceQuoteCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // User input 
            int age = 32;
            int carYear = 2010;
            string carMake = "Porsche";
            bool hasSpeedingTicket = true;
            bool hasDUI = false;
            bool isFullCoverage = true;

            // Base quote
            decimal baseQuote = 50;

            // Age adjustments
            if (age <= 18)
                baseQuote += 100;
            else if (age >= 19 && age <= 25)
                baseQuote += 50;
            else
                baseQuote += 25;

            // Car year adjustments
            if (carYear < 2000)
                baseQuote += 25;
            else if (carYear > 2015)
                baseQuote += 25;

            // Car make adjustments
            if (carMake == "Porsche")
            {
                baseQuote += 25;
                if (carMake == "911 Carrera")
                    baseQuote += 25;
            }

            // Speeding ticket adjustments
            if (hasSpeedingTicket)
                baseQuote += 10;

            // DUI adjustment
            if (hasDUI)
                baseQuote *= 1.25m;

            // Full coverage adjustment
            if (isFullCoverage)
                baseQuote *= 1.5m;

            // Display the final quote
            Console.WriteLine($"Your insurance quote: ${baseQuote} per month");

           
        }
    }
}


namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insures.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insure insure = db.Insures.Find(id);
            if (insure == null)
            {
                return HttpNotFound();
            }
            return View(insure);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insure insure)
        {
            if (ModelState.IsValid)
            {
                db.Insures.Add(insure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insure);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insure insure = db.Insures.Find(id);
            if (insure == null)
            {
                return HttpNotFound();
            }
            return View(insure);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insure insure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insure);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insure insure = db.Insures.Find(id);
            if (insure == null)
            {
                return HttpNotFound();
            }
            return View(insure);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insure insure = db.Insures.Find(id);
            db.Insures.Remove(insure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
