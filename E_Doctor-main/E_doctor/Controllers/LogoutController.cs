using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Logouts()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}