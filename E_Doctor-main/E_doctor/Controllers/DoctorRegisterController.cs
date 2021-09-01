using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class DoctorRegisterController : Controller
    {
        // GET: DoctorRegister
        [HttpGet]
        public ActionResult Index()
        {
            Doctor dbModel = new Doctor();
            return View(dbModel);
        }
        [HttpPost]
        public ActionResult Index(Doctor usermodel)
        {
            using (DbModelDoctor dbModel = new DbModelDoctor())
            {
                dbModel.Doctors.Add(usermodel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registered";
            return View("Index", new Doctor());
        }
    }
}