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
using Microsoft.AspNet.Identity;

namespace Centric_Project.Controllers
{
    [Authorize]
    public class userDataController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: userData
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.userData.ToList());
        }

        // GET: userData/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.userData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: userData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,businessUnit,hireDate,title")] userData userData)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userData.ID = memberID;
                //userData.ID = Guid.NewGuid();
                db.userData.Add(userData);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("duplicateuser");
                }
                return RedirectToAction("Index");
            }

            return View(userData);
        }

        // GET: userData/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.userData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: userData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,businessUnit,hireDate,title")] userData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userData);
        }

        // GET: userData/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.userData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: userData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            userData userData = db.userData.Find(id);
            db.userData.Remove(userData);
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
