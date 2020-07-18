using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EATApp.Models;

namespace EATApp.Controllers
{
    public class TeacherController : Controller
    {
        private TafeDBEntities db = new TafeDBEntities();

        // GET: Teacher
        public ActionResult Index()
        {
            var studentsessions = db.studentsessions.Include(s => s.session).Include(s => s.student);
            return View(studentsessions.ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? session_sessionID, string student_StudentID)
        {
            if (student_StudentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentsession studentsession = db.studentsessions.Find(session_sessionID, student_StudentID);
            if (studentsession == null)
            {
                return HttpNotFound();
            }
            //studentsession data = db.studentsessions.Find(session_sessionID,student_StudentID);
            //if (data == null)
            //{
            //    return HttpNotFound();
            //}
            //var groupedData = db.studentsessions.Where(s => s.student_StudentID == data.student_StudentID).ToList();

            //return View(groupedData);
            //String connectionString = "Data Source=LAPTOP-I9V7HD8J\SQLEXPRESS01;Initial Catalog=TafeDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            //String sql = "SELECT * FROM students";
            //System.Data.SqlClient.SqlCommand cmd = new SqlCommand(sql, connectionString);

            //using (System.Data.SqlClient.SqlConnection connectionString = new System.Data.SqlClient.SqlConnection(connectionString))
            //{
            //    connectionString.Open();
            //   System.Data.SqlClient.SqlDataReader rdr = cmd.ExecuteReader();
            //}

            //ViewData.Add("students", rdr);
            // String sql = "SELECT * FROM studentssession";
            //ViewBag.session_sessionID = new SelectList(db.sessions, "sessionID", "Date");
            //ViewBag.student_StudentID = new SelectList(db.students, "StudentID", "GivenName");
            //return View();

            return View(studentsession);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            ViewBag.session_sessionID = new SelectList(db.sessions, "sessionID", "Date");
            ViewBag.student_StudentID = new SelectList(db.students, "StudentID", "GivenName");
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SignIn,SignOut,session_sessionID,student_StudentID")] studentsession studentsession)
        {
            if (ModelState.IsValid)
            {
                db.studentsessions.Add(studentsession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_sessionID = new SelectList(db.sessions, "sessionID", "Date", studentsession.session_sessionID);
            ViewBag.student_StudentID = new SelectList(db.students, "StudentID", "GivenName", studentsession.student_StudentID);
            return View(studentsession);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? session_sessionID, string student_StudentID)
        {
            if (student_StudentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentsession studentsession = db.studentsessions.Find(session_sessionID, student_StudentID);
            if (studentsession == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_sessionID = new SelectList(db.sessions, "sessionID", "Date", studentsession.session_sessionID);
            ViewBag.student_StudentID = new SelectList(db.students, "StudentID", "GivenName", studentsession.student_StudentID);
            return View(studentsession);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SignIn,SignOut,session_sessionID,student_StudentID")] studentsession studentsession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_sessionID = new SelectList(db.sessions, "sessionID", "Date", studentsession.session_sessionID);
            ViewBag.student_StudentID = new SelectList(db.students, "StudentID", "GivenName", studentsession.student_StudentID);
            return View(studentsession);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentsession studentsession = db.studentsessions.Find(id);
            if (studentsession == null)
            {
                return HttpNotFound();
            }
            return View(studentsession);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentsession studentsession = db.studentsessions.Find(id);
            db.studentsessions.Remove(studentsession);
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
