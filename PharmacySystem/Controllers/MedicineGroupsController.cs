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
    public class MedicineGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicineGroups
        [Authorize]
        public ActionResult Index()
        {
            return View(db.MedicineGroups.ToList());
        }

        // GET: MedicineGroups/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineGroup medicineGroup = db.MedicineGroups.Find(id);
            if (medicineGroup == null)
            {
                return HttpNotFound();
            }
            return View(medicineGroup);
        }

        // GET: MedicineGroups/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicineGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineGroupID,MedicineGroupName")] MedicineGroup medicineGroup)
        {
            if (ModelState.IsValid)
            {
                db.MedicineGroups.Add(medicineGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicineGroup);
        }

        // GET: MedicineGroups/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineGroup medicineGroup = db.MedicineGroups.Find(id);
            if (medicineGroup == null)
            {
                return HttpNotFound();
            }
            return View(medicineGroup);
        }

        // POST: MedicineGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineGroupID,MedicineGroupName")] MedicineGroup medicineGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicineGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicineGroup);
        }

        // GET: MedicineGroups/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineGroup medicineGroup = db.MedicineGroups.Find(id);
            if (medicineGroup == null)
            {
                return HttpNotFound();
            }
            return View(medicineGroup);
        }

        // POST: MedicineGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicineGroup medicineGroup = db.MedicineGroups.Find(id);
            db.MedicineGroups.Remove(medicineGroup);
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
