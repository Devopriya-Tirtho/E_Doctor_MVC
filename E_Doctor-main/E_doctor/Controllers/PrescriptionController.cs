using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        [HttpGet]
        public ActionResult Index(int id=0)
        {
            Prescription userModel = new Prescription();
            return View(userModel);
        }

        [HttpPost]

        public ActionResult Index(Prescription usermodel)
        {
            using (precriptionDbModels dbModel = new precriptionDbModels())
            {
                dbModel.Prescriptions.Add(usermodel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Prescription Inserted";
            return View("Index", new Prescription());
        }
    }
}