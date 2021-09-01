using RegistrationUserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUserMVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

            [HttpGet]
        public ActionResult Index(int id=0)
        {
            BlogInsert userModel = new BlogInsert();
            return View(userModel);
        }

        [HttpPost]

        public ActionResult Index(BlogInsert usermodel)
        {
            using (blogModelDb dbModel = new blogModelDb())
            {
                dbModel.BlogInserts.Add(usermodel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Blog Inserted";
            return RedirectToAction("Blogshow", "Blog");
        }

        public ActionResult Blogshow()
        {
            blogModelDb userModel = new blogModelDb();
            return View(from emp in userModel.BlogInserts.ToList() select emp);
        }
    }
}