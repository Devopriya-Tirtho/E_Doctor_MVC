using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Autherized(RegistrationUserMVC.Models.login userModel)
        {
            using (DBModels db = new DBModels())
            {
                var userDetails = db.Registrations.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    userModel.LoginErrorMessage = "Wrong UserName or Password";
                    return View("Index",userModel);

                }
                else
                {
                    Session["username"] =userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
              
        }

    }
}