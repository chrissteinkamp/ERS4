using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERS4.Models;

namespace ERS4.Controllers
{
    [RequireHttps]
    public class EmployeeController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Employee
        public ActionResult Index(string rate, string searchString)
        {
            var rateLst = new List<string>();

            var RateQry = from r in db.Employee
                           orderby r.RATING
                           select r.RATING;

            rateLst.AddRange(RateQry.Distinct());
            ViewBag.rate = new SelectList(rateLst);

            var rates = from e in db.Employee
                         select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                rates = rates.Where(s => s.LASTNAME.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(rate))
            {
                rates = rates.Where(x => x.RATING == rate);
            }

            return View(rates);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModels employeeModels = db.Employee.Find(id);
            if (employeeModels == null)
            {
                return HttpNotFound();
            }
            return View(employeeModels);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FIRSTNAME,LASTNAME,USERNAME,STARTDATE,DEPARTMENT,SALES,RATING")] EmployeeModels employeeModels)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employeeModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeModels);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModels employeeModels = db.Employee.Find(id);
            if (employeeModels == null)
            {
                return HttpNotFound();
            }
            return View(employeeModels);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FIRSTNAME,LASTNAME,USERNAME,STARTDATE,DEPARTMENT,SALES,RATING")] EmployeeModels employeeModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeModels);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModels employeeModels = db.Employee.Find(id);
            if (employeeModels == null)
            {
                return HttpNotFound();
            }
            return View(employeeModels);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModels employeeModels = db.Employee.Find(id);
            db.Employee.Remove(employeeModels);
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
