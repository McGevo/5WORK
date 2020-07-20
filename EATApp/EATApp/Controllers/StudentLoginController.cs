using EATApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EATApp.Controllers
{
    public class StudentLoginController : Controller
    {
        // GET: StudentLogin
        public ActionResult StudentLoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(EATApp.Models.student studentModel)
        {
            using (TafeDBEntities db = new TafeDBEntities())
            {
                student userDetails = db.students.Where(x => x.EmailAddress == studentModel.EmailAddress && x.StudentID == studentModel.StudentID).FirstOrDefault();
                if (userDetails == null)
                {
                    studentModel.LoginErrorMessage = "Email or Password is incorrect";
                    return View("StudentLoginView", studentModel);
                }
                else
                {
                    Session["userID"] = userDetails.StudentID;
                    return RedirectToAction("Index", "attendance");
                }
            }


        }
    }
}