using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class SearchController : Controller
    {
        DBModels db = new DBModels();

        public ActionResult Index(string searching)
        {
            return View(db.Calenders.Where(x => x.PatientName.Contains(searching)|| searching==null).ToList());
        }

    }
}