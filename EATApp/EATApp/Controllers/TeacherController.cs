using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EATApp.Models;

namespace EATApp.Controllers
{
    public class TeacherController : Controller
    {
        private EATModelEntities1 db = new EATModelEntities1();

        // GET: Teacher
        public async Task<ActionResult> Index()
        {
            var studentSessions = db.StudentSessions.Include(s => s.Session).Include(s => s.Student);
            return View(await studentSessions.ToListAsync());
        }

        // GET: Teacher/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSession studentSession = await db.StudentSessions.FindAsync(id);
            if (studentSession == null)
            {
                return HttpNotFound();
            }
            return View(studentSession);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            ViewBag.SessionID = new SelectList(db.Sessions, "SessionID", "Date");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SessionID,StudentID,SignIn,SignOut")] StudentSession studentSession)
        {
            if (ModelState.IsValid)
            {
                db.StudentSessions.Add(studentSession);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SessionID = new SelectList(db.Sessions, "SessionID", "Date", studentSession.SessionID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentSession.StudentID);
            return View(studentSession);
        }

        // GET: Teacher/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSession studentSession = await db.StudentSessions.FindAsync(id);
            if (studentSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.SessionID = new SelectList(db.Sessions, "SessionID", "Date", studentSession.SessionID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentSession.StudentID);
            return View(studentSession);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SessionID,StudentID,SignIn,SignOut")] StudentSession studentSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentSession).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SessionID = new SelectList(db.Sessions, "SessionID", "Date", studentSession.SessionID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentSession.StudentID);
            return View(studentSession);
        }

        // GET: Teacher/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSession studentSession = await db.StudentSessions.FindAsync(id);
            if (studentSession == null)
            {
                return HttpNotFound();
            }
            return View(studentSession);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            StudentSession studentSession = await db.StudentSessions.FindAsync(id);
            db.StudentSessions.Remove(studentSession);
            await db.SaveChangesAsync();
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
