using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            Registration userModel = new Registration();

            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Registration userModel)

        {
            using (DBModels dbModel = new DBModels())
            {
                if(dbModel.Registrations.Any(x=>x.UserName==userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", userModel);
                }
                dbModel.Registrations.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return RedirectToAction("Index","Login");



        }
    }
}