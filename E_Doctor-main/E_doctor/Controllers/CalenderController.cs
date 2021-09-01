using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class CalenderController : Controller
    {
        // GET: Calender
        [HttpGet]
        public ActionResult Index(int id=0)
        {
            Calender userModel = new Calender();


            return View(userModel);
        }

       


        [HttpPost]




        public ActionResult Index(Calender userModel)

        {
            using (DBModels dbModel = new DBModels())
            {
                if ((dbModel.Calenders.Any(x => x.AppointmentDate == userModel.AppointmentDate)) && (dbModel.Calenders.Any(x => x.AppointmentTime == userModel.AppointmentTime)))
                {
                    ViewBag.DuplicateMessage = "Already exist.";
                    return View("Index", userModel);
                }
              
                dbModel.Calenders.Add(userModel);
                dbModel.SaveChanges();
    
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful";
            return RedirectToAction("Index", "Home");


        }
        

        }


    }
