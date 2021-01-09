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
    public class TrainStationsController : Controller
    {
        private NewestModels db = new NewestModels();

        // GET: TrainStations
        public ActionResult Index()
        {
            return View(db.TrainStations.ToList());
        }

        // GET: TrainStations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainStation trainStation = db.TrainStations.Find(id);
            if (trainStation == null)
            {
                return HttpNotFound();
            }
            return View(trainStation);
        }

        // GET: TrainStations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Suburb,Name,Latitude,Longitude")] TrainStation trainStation)
        {
            if (ModelState.IsValid)
            {
                db.TrainStations.Add(trainStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainStation);
        }

        // GET: TrainStations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainStation trainStation = db.TrainStations.Find(id);
            if (trainStation == null)
            {
                return HttpNotFound();
            }
            return View(trainStation);
        }

        // POST: TrainStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Suburb,Name,Latitude,Longitude")] TrainStation trainStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainStation);
        }

        // GET: TrainStations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainStation trainStation = db.TrainStations.Find(id);
            if (trainStation == null)
            {
                return HttpNotFound();
            }
            return View(trainStation);
        }

        // POST: TrainStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainStation trainStation = db.TrainStations.Find(id);
            db.TrainStations.Remove(trainStation);
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
