using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalVersion.Models;

namespace FinalVersion.Controllers
{
    public class SchoolDetailsController : Controller
    {
        private NewestModels db = new NewestModels();

        // GET: SchoolDetails
        public ActionResult Index()
        {
            return View(db.SchoolDetails.ToList());
        }

        // GET: SchoolDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolDetail schoolDetail = db.SchoolDetails.Find(id);
            if (schoolDetail == null)
            {
                return HttpNotFound();
            }
            return View(schoolDetail);
        }

        // GET: SchoolDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Phone_number,School_Name,School_Type,Suburb,URL,Rating")] SchoolDetail schoolDetail)
        {
            if (ModelState.IsValid)
            {
                db.SchoolDetails.Add(schoolDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schoolDetail);
        }

        // GET: SchoolDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolDetail schoolDetail = db.SchoolDetails.Find(id);
            if (schoolDetail == null)
            {
                return HttpNotFound();
            }
            return View(schoolDetail);
        }

        // POST: SchoolDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Phone_number,School_Name,School_Type,Suburb,URL,Rating")] SchoolDetail schoolDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolDetail);
        }

        // GET: SchoolDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolDetail schoolDetail = db.SchoolDetails.Find(id);
            if (schoolDetail == null)
            {
                return HttpNotFound();
            }
            return View(schoolDetail);
        }

        // POST: SchoolDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolDetail schoolDetail = db.SchoolDetails.Find(id);
            db.SchoolDetails.Remove(schoolDetail);
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
