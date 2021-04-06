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
    [Authorize]
    public class recognitionUsersController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: recognitionUsers
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.recognitionUsers.ToList());
        }

        // GET: recognitionUsers/Details/5
        [AllowAnonymous]
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

        // GET: recognitionUsers/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.userData, "ID", "fullName");
            return View();
        }

        // POST: recognitionUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionUserID,recoginzor,recognized,date,award,reason")] recognitionUser recognitionUser)
        {
            if (ModelState.IsValid)
            {
                db.recognitionUsers.Add(recognitionUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recognitionUser);
        }

        // GET: recognitionUsers/Edit/5
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

        // POST: recognitionUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionUserID,recoginzor,recognized,date,award,reason")] recognitionUser recognitionUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognitionUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognitionUser);
        }

        // GET: recognitionUsers/Delete/5
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

        // POST: recognitionUsers/Delete/5
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
