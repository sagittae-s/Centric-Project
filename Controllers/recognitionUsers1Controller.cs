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
    public class recognitionUsers1Controller : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: recognitionUsers1
        public ActionResult Index()
        {
            return View(db.recognitionUsers.Include(r=>r.personReceiving).Include(r=>r.personGiving).ToList());
        }

        // GET: recognitionUsers1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitionUser recognitionUser = db.recognitionUsers.Find(id);
            if (recognitionUser == null)
            {
                return HttpNotFound();
            }
            return View(recognitionUser);
        }

        // GET: recognitionUsers1/Create
        public ActionResult Create()
        {
            ViewBag.recognizor = new SelectList(db.userData, "ID", "fullName");
            ViewBag.recognized = new SelectList(db.userData, "ID", "fullName");
            return View();
        }

        // POST: recognitionUsers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionUserID,recognizor,recognized,date,award,reason")] recognitionUser recognitionUser)
        {
            if (ModelState.IsValid)
            {
                db.recognitionUsers.Add(recognitionUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recognitionUser);
        }

        // GET: recognitionUsers1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitionUser recognitionUser = db.recognitionUsers.Find(id);
            if (recognitionUser == null)
            {
                return HttpNotFound();
            }
            return View(recognitionUser);
        }

        // POST: recognitionUsers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionUserID,recognizor,recognized,date,award,reason")] recognitionUser recognitionUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognitionUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognitionUser);
        }

        // GET: recognitionUsers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitionUser recognitionUser = db.recognitionUsers.Find(id);
            if (recognitionUser == null)
            {
                return HttpNotFound();
            }
            return View(recognitionUser);
        }

        // POST: recognitionUsers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recognitionUser recognitionUser = db.recognitionUsers.Find(id);
            db.recognitionUsers.Remove(recognitionUser);
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
