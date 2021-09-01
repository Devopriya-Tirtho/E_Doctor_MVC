using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class RemedyController : Controller
    {
        // GET: Remedy
     
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            Remedy userModel = new Remedy();
            return View(userModel);
        }

        [HttpPost]

        public ActionResult Index(Remedy usermodel)
        {
            using (DbModelRemedy dbModel = new DbModelRemedy())
            {
                dbModel.Remedies.Add(usermodel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Remedies Inserted";
            return View("Index", new Remedy());
        }

        public ActionResult Remedyshow()
        {
            DbModelRemedy userModel = new DbModelRemedy();
            return View(from emp in userModel.Remedies.ToList() select emp);
        }
    }
}