using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centric_Project.DAL;
using Centric_Project.Models;

namespace Centric_Project.Controllers
{
    public class recognitionsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: recognitions
        public ActionResult Index()
        {
            return View(db.recognitions.ToList());
        }

        // GET: recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitions recognitions = db.recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            return View(recognitions);
        }

        // GET: recognitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: recognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionsID,award,recognizor,recognized,recognitionDate")] recognitions recognitions)
        {
            if (ModelState.IsValid)
            {
                db.recognitions.Add(recognitions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recognitions);
        }

        // GET: recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitions recognitions = db.recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            return View(recognitions);
        }

        // POST: recognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionsID,award,recognizor,recognized,recognitionDate")] recognitions recognitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognitions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognitions);
        }

        // GET: recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitions recognitions = db.recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            return View(recognitions);
        }

        // POST: recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recognitions recognitions = db.recognitions.Find(id);
            db.recognitions.Remove(recognitions);
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
