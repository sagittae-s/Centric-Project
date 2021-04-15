using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Centric_Project.DAL;
using Centric_Project.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace Centric_Project.Controllers
{
    [Authorize]
    public class recognitionUsers1Controller : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: recognitionUsers1
        [AllowAnonymous]
        public ActionResult Index(int? page, string searchString)
        {
            //Paging
            int pgSize = 10;
            int pageNumber = (page ?? 1);
            //var user = from r in db.recognitionUsers select r;
            //sort the records
            //user = db.recognitionUsers.OrderBy(r => r.recognizor);
            //check to see if a search was requested and do it
            //if(!String.IsNullOrEmpty(searchString))
            //{
                //user = user.Where(r => r.recognizor.Contains(searchString));
            //}
            var user = db.recognitionUsers.OrderBy(r => r.recognizor);
            var userList = user.ToPagedList(pageNumber, pgSize);
            return View(userList);
            //Original Below
            //return View(db.recognitionUsers.ToList());
        }

        // GET: recognitionUsers1/Details/5
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

        // GET: recognitionUsers1/Create

        public ActionResult Create()
        {
            //DDL in alphabetical order
            var employeeData = db.userData.OrderBy(c => c.lastName).ThenBy(c => c.firstName);

            string ID = User.Identity.GetUserId();
            var employeeList = new SelectList(employeeData, "ID", "fullName");
            employeeList = new SelectList(employeeList.Where(x => x.Value != ID).ToList(), "Value", "Text");
            ViewBag.recognizor = employeeList;
            

            ViewBag.recognized = employeeList;
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
                try
                {
                    
                    Guid memberID;
                    Guid.TryParse(User.Identity.GetUserId(), out memberID);
                    recognitionUser.recognizor = memberID;
                    db.recognitionUsers.Add(recognitionUser);
                    db.SaveChanges();

                    var employee = db.userData.Find(recognitionUser.recognized);
                    var email = employee.email; //Error comes up when creating a recognition
                    var msg = "Hi, you just got recognized! Check out your profile for more details.";
                    MailMessage myMessage = new MailMessage();
                    MailAddress from = new MailAddress("mis4200centric@gmail.com");
                    myMessage.From = from;
                    myMessage.To.Add(email);
                    myMessage.Subject = "Core Value Recognition";
                    myMessage.Body = msg;
                    try
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("mis4200centric@gmail.com", "Mis4200!");
                        smtp.EnableSsl = true;
                        smtp.Send(myMessage);
                        TempData["mailError"] = "";
                    }
                    catch (Exception ex)
                    {
                        TempData["mailError"] = ex.Message;
                        return View("mailError");
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    //Add error message return
                }
            }
            //Attempting to add an email notification

            

            return View(recognitionUser);
        }

        // GET: recognitionUsers1/Edit/5
        public ActionResult Edit(int? id)
        {
            var employeeData = db.userData.OrderBy(c => c.lastName).ThenBy(c => c.firstName);

            //string ID = User.Identity.GetUserId();
            //var employeeList = new SelectList(employeeData, "ID", "fullName");
            //employeeList = new SelectList(employeeList.Where(x => x.Value != ID).ToList(), "Value", "Text", recognitionUser.recognized);
            //ViewBag.recognizor = employeeList;


            //ViewBag.recognized = employeeList;

            //ViewBag.recognizor = new SelectList(db.userData, "ID", "fullName");
            //ViewBag.recognized = new SelectList(db.userData, "ID", "fullName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognitionUser recognitionUser = db.recognitionUsers.Find(id);
            if (recognitionUser == null)
            {
                return HttpNotFound();
            }
            {
                string ID = User.Identity.GetUserId();
                var employeeList = new SelectList(employeeData, "ID", "fullName");
                employeeList = new SelectList(employeeList.Where(x => x.Value != ID).ToList(), "Value", "Text", recognitionUser.recognized);
                ViewBag.recognizor = employeeList;


                ViewBag.recognized = employeeList;
                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                if (memberId == recognitionUser.recognizor)
                {
                    return View(recognitionUser);
                }
                else
                {
                    return View("NoEdit");
                }
            }

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
