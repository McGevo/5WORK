using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EATApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomeView()
        {
            return View();
        }

        public ActionResult LecturerLoginPage()
        {
            return RedirectToAction("LoginView", "Login");
        }

        public ActionResult StudentLoginPage()
        {
            return RedirectToAction("StudentLoginView", "StudentLogin");
        }
    }
}