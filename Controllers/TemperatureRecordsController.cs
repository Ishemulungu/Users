using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Temperature_Recording.Models;

namespace Temperature_Recording.Controllers
{
    public class TemperatureRecordsController : Controller
    {
        private Temperature_RecordsEntities db = new Temperature_RecordsEntities();

        // GET: TemperatureRecords
        public ActionResult Index()
        {
            var temperatureRecords = db.TemperatureRecords.Include(t => t.User);
            return View(temperatureRecords.ToList());
        }

        // GET: TemperatureRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemperatureRecord temperatureRecord = db.TemperatureRecords.Find(id);
            if (temperatureRecord == null)
            {
                return HttpNotFound();
            }
            return View(temperatureRecord);
        }

        // GET: TemperatureRecords/Create
        public ActionResult Create()
        {
            ViewBag.UsersID = new SelectList(db.Users, "UsersID", "FullName");
            return View();
        }

        // POST: TemperatureRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemperatureRecord1,UsersID,TemperatureReading,DateCaptured")] TemperatureRecord temperatureRecord)
        {
            if (ModelState.IsValid)
            {
                db.TemperatureRecords.Add(temperatureRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsersID = new SelectList(db.Users, "UsersID", "FullName", temperatureRecord.UsersID);
            return View(temperatureRecord);
        }

        // GET: TemperatureRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemperatureRecord temperatureRecord = db.TemperatureRecords.Find(id);
            if (temperatureRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsersID = new SelectList(db.Users, "UsersID", "FullName", temperatureRecord.UsersID);
            return View(temperatureRecord);
        }

        // POST: TemperatureRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemperatureRecord1,UsersID,TemperatureReading,DateCaptured")] TemperatureRecord temperatureRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temperatureRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsersID = new SelectList(db.Users, "UsersID", "FullName", temperatureRecord.UsersID);
            return View(temperatureRecord);
        }

        // GET: TemperatureRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemperatureRecord temperatureRecord = db.TemperatureRecords.Find(id);
            if (temperatureRecord == null)
            {
                return HttpNotFound();
            }
            return View(temperatureRecord);
        }

        // POST: TemperatureRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemperatureRecord temperatureRecord = db.TemperatureRecords.Find(id);
            db.TemperatureRecords.Remove(temperatureRecord);
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
