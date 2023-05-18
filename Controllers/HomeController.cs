using managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace managment.Views.Home
{
    public class HomeController : Controller
    {

        schoolmanage db = new schoolmanage();
        // GET: Form

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult std_inf(string name1, string relig, string email, string pwd, string gender, string num, HttpPostedFileBase file)
        {
            // batch bt = db.batches.Where(m => m.b_code.Equals(batch)).FirstOrDefault();

            std_info info = new std_info();
            string file_name = file.FileName.ToString();
            string path = "~/Uploads/" + file_name;
            file.SaveAs(Server.MapPath(path));
            info.s_pic = path;
            info.s_name = name1;
            info.s_relig = relig;
            info.s_num = num;
            info.s_gender = gender;
            info.s_email = email;
            info.s_pass = pwd;
            info.s_batchid = 6;

            Session["st_email"] = email;
            TempData["first"] = "First View";
            TempData.Keep();

            db.std_info.Add(info);
            db.SaveChanges();



            return RedirectToAction("Index");
        }



        public ActionResult std_ad(string city, string pob, string dob, string Address)
        {
            string email = Session["st_email"].ToString();
            std_info std = db.std_info.Where(m => m.s_email.Equals(email)).FirstOrDefault();
            std_add st_add = new std_add();
            st_add.s_city = city;
            st_add.p_o_b = pob;
            st_add.d_o_b = dob;
            st_add.s_address = Address;
            st_add.s_id = std.s_id;

            TempData["first"] = "First View";
            TempData["second"] = "Second View";
            TempData.Keep();


            db.std_add.Add(st_add);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult std_parent(string fname, string fcon, string femail, string fcnic, string mname, string mcon)
        {
            string email = Session["st_email"].ToString();
            std_info std = db.std_info.Where(m => m.s_email.Equals(email)).FirstOrDefault();
            parent_info st_par = new parent_info();
            st_par.f_name = fname;
            st_par.f_contact = fcon;
            st_par.m_name = mname;
            st_par.m_contact = mcon;
            st_par.f_cnic = fcnic;
            st_par.s_id = std.s_id;
            st_par.f_email = femail;

            TempData["first"] = "First View";
            TempData["second"] = "Second View";
            TempData["third"] = "Third View";
            TempData.Keep();

            db.parent_info.Add(st_par);
            int a = db.SaveChanges();




            return RedirectToAction("Index");
        }







        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string email , string pass)
        {
            std_info obj = db.std_info.Where(m => m.s_email.Equals(email) && m.s_pass.Equals(pass)).FirstOrDefault();

            if (obj != null)
            {
                Session["u_name"] = obj.s_name;
                Session["u_relig"] = obj.s_relig;
                Session["u_num"] = obj.s_num;
                Session["u_gender"] = obj.s_gender;
                Session["u_email"] = obj.s_email;
                Session["u_batch"] = obj.s_batchid;
                Session["u_enr"] = obj.s_cpass;
                Session["u_image"] = obj.s_pic;
                Session["u_id"] = obj.s_id;



                return RedirectToAction("Index","User");
            }

            return View();
        }










        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            return RedirectToAction("Index");
        }



    }
}