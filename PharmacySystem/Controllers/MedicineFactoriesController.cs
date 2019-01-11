using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PharmacySystem.Models;

namespace PharmacySystem.Controllers
{
    public class MedicineFactoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicineFactories
        public ActionResult Index()
        {
            return View(db.MedicineFactories.ToList());
        }

        // GET: MedicineFactories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineFactory medicineFactory = db.MedicineFactories.Find(id);
            if (medicineFactory == null)
            {
                return HttpNotFound();
            }
            return View(medicineFactory);
        }

        // GET: MedicineFactories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicineFactories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineFactoryID,MedicineFactoryName")] MedicineFactory medicineFactory)
        {
            if (ModelState.IsValid)
            {
                db.MedicineFactories.Add(medicineFactory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicineFactory);
        }

        // GET: MedicineFactories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineFactory medicineFactory = db.MedicineFactories.Find(id);
            if (medicineFactory == null)
            {
                return HttpNotFound();
            }
            return View(medicineFactory);
        }

        // POST: MedicineFactories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineFactoryID,MedicineFactoryName")] MedicineFactory medicineFactory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicineFactory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicineFactory);
        }

        // GET: MedicineFactories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineFactory medicineFactory = db.MedicineFactories.Find(id);
            if (medicineFactory == null)
            {
                return HttpNotFound();
            }
            return View(medicineFactory);
        }

        // POST: MedicineFactories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicineFactory medicineFactory = db.MedicineFactories.Find(id);
            db.MedicineFactories.Remove(medicineFactory);
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
