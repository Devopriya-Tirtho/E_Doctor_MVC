using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class DoctorLoginController : Controller
    {
        // GET: DoctorLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherized(RegistrationUserMVC.Models.Doctorlogin userModel)
        {
            using (DbModelDoctor db = new DbModelDoctor())
            {
                var userDetails = db.Doctors.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong UserName or Password";
                    return View("Index", userModel);

                }
                else
                {
                    Session["username"] = userDetails.Email;
                    return RedirectToAction("Index", "Prescription");
                }
            }

        }
    }
}