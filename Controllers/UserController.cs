using managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace managment.Controllers
{
    public class UserController : Controller
    {
        schoolmanage db = new schoolmanage();

        // GET: User
        public ActionResult Index()
        {
            var obj = db.std_course.ToList();
            return View(obj);
        }


        public ActionResult Course()
        {
            return View("Course");
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult contact()
        {
            return View("contact");
        }

    }
}