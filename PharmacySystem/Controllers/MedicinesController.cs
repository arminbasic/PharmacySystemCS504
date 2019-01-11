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
    public class MedicinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicines
        [Authorize]
        public ActionResult Index(string g, string searchString, string f)
            
        {
            var mgroupList = new List<string>();

            var mgroupQry = from d in db.Medicines
                             orderby d.MedicineGroup.MedicineGroupName
                             select d.MedicineGroup.MedicineGroupName;

            mgroupList.AddRange(mgroupQry.Distinct());
            ViewBag.g = new SelectList(mgroupList);

            var mfactList = new List<string>();
            var mfactQry = from d in db.Medicines
                           orderby d.MedicineFactory.MedicineFactoryName
                            select d.MedicineFactory.MedicineFactoryName;

            mfactList.AddRange(mfactQry.Distinct());
            ViewBag.f = new SelectList(mfactList);

            var meds = from m in db.Medicines
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                meds = meds.Where(s => s.MedicineName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(g))
            {
                meds = meds.Where(x => x.MedicineGroup.MedicineGroupName == g);
            }

            if (!string.IsNullOrEmpty(f))
            {
                meds = meds.Where(c => c.MedicineFactory.MedicineFactoryName == f);

            }

           
            return View(meds.ToList());
        }

        // GET: Medicines/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: Medicines/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MedicineFactoryID = new SelectList(db.MedicineFactories, "MedicineFactoryID", "MedicineFactoryName");
            ViewBag.MedicinegroupID = new SelectList(db.MedicineGroups, "MedicineGroupID", "MedicineGroupName");
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineID,MedicineName,NumberAvailable,MedicinegroupID,MedicineFactoryID")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicineFactoryID = new SelectList(db.MedicineFactories, "MedicineFactoryID", "MedicineFactoryName", medicine.MedicineFactoryID);
            ViewBag.MedicinegroupID = new SelectList(db.MedicineGroups, "MedicineGroupID", "MedicineGroupName", medicine.MedicinegroupID);
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineFactoryID = new SelectList(db.MedicineFactories, "MedicineFactoryID", "MedicineFactoryName", medicine.MedicineFactoryID);
            ViewBag.MedicinegroupID = new SelectList(db.MedicineGroups, "MedicineGroupID", "MedicineGroupName", medicine.MedicinegroupID);
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineID,MedicineName,NumberAvailable,MedicinegroupID,MedicineFactoryID")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicineFactoryID = new SelectList(db.MedicineFactories, "MedicineFactoryID", "MedicineFactoryName", medicine.MedicineFactoryID);
            ViewBag.MedicinegroupID = new SelectList(db.MedicineGroups, "MedicineGroupID", "MedicineGroupName", medicine.MedicinegroupID);
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            db.Medicines.Remove(medicine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PrescriptionPatient(int? id)
        {

            var prescriptions = from m in db.Prescriptions
                                select m;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            else

                prescriptions = prescriptions.Where(s => s.medicine.MedicineID == id);

            return View(prescriptions.ToList());

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
