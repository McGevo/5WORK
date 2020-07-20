using EATApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EATApp.Controllers
{
    public class LoginController : Controller
    {
        

        public ActionResult LoginView()
        {
            ViewBag.Message = "LoginView Page";

            return View();
        }
        [HttpPost]
        public ActionResult Authorise(EATApp.Models.lecturer lecturerModel)
        {
            using (TafeDBEntities db = new TafeDBEntities())
            {
                var userDetails = db.lecturers.Where(x => x.EmailAddress == lecturerModel.EmailAddress && x.LecturerID == lecturerModel.LecturerID).FirstOrDefault();
                if(userDetails==null)
                {
                    lecturerModel.LoginErrorMessage = "Email or Password is incorrect";
                    return View("LoginView", lecturerModel);
                }
                else
                {
                    Session["userID"] = userDetails.LecturerID;
                    return RedirectToAction("Index", "Teacher");
                }
            }

                
        }
    }
}