using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationUserMVC.Models;

namespace RegistrationUserMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            DBModels dbModel = new DBModels();
            return View(dbModel);
           
        }
       


        [HttpPost]
        public ActionResult Index(DBModels userModel)
        {

            DBModels dbModel = new DBModels();
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "Calender");

            }
            else
            {
                return RedirectToAction("Index", "Login");

            }

        }

        public ActionResult precript(DBModels userModel)
        {

            DBModels dbModel = new DBModels();
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "Prescription");

            }
            else
            {
                return RedirectToAction("Index", "DoctorLogin");

            }

        }

        

        public ActionResult View()
        {
            DBModels userModel = new DBModels();
            return View(from emp in userModel.Calenders.ToList() select emp); 
        }



    }
}