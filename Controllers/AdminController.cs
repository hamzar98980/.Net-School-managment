using managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace managment.Controllers
{
    public class AdminController : Controller
    {
        schoolmanage db = new schoolmanage();
        // GET: Admin
        [HttpGet]

      


    /*    public ActionResult myadmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult myadmin(string loginUsername, string loginPassword)
        {
            if (loginUsername.Equals("admin") && loginPassword.Equals("admin123"))
            {
                Session["admin"] = "Admin";
                return RedirectToAction("admin_dash");
            }
            return View();
        }
*/
        public ActionResult madmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult madmin(string loginUsername, string loginPassword)
        {
            if (loginUsername.Equals("admin") && loginPassword.Equals("admin123"))
            {
                Session["admin"] = "Admin";
                return RedirectToAction("admin_dash");
            }
            return View();
        }


        public ActionResult admin_dash()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("myadmin");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Session.Remove("admin");
            return RedirectToAction("myadmin");
        }
    }
}