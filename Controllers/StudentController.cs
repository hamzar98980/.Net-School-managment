using managment.Models;
using managment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace managment.Controllers
{
    public class StudentController : Controller
    {
        schoolmanage db = new schoolmanage();
        // GET: Student
        public ActionResult Index(string email, string pass)
        {

            string email1 = Session["u_email"].ToString();
            std_info info = db.std_info.Where(m => m.s_email.Equals(email1)).FirstOrDefault();
            int std_id = info.s_id;
            var fee = db.st_fees.Where(x => x.s_id == std_id).ToList();

          
            var batch = info.s_batchid;

            var tables = new StudentViewModel
            {
                st_fees = db.st_fees.Where(x => x.s_id == std_id).ToList(),
                std_mat = db.std_mat.Where(m => m.sm_id == batch).ToList(),
                exam = db.exams.Where(m => m.e_batch == batch).ToList(),
                Assingment = db.Assingments.Where(m => m.as_batch == batch).ToList(),
                exam_result = db.exam_result.Where(x => x.s_id == std_id).ToList(),
                notice = db.notices.Where(c => c.n_batch == batch).ToList()

            };

            //ViewBag.fees = fee.f_fees;
            //ViewBag.month = fee.f_month;
            //ViewBag.date = fee.f_date;
            return View(tables);

        }


        [HttpPost]
        public ActionResult assing(string name1,string desc,int ass ,HttpPostedFileBase file)
        {
            as_submit subm = new as_submit();
            string file_name = file.FileName.ToString();
            string path = "~/stdassing/" + file_name;
            file.SaveAs(Server.MapPath(path));
            subm.su_submit = path;
            subm.s_id = int.Parse(Session["u_id"].ToString());
            subm.su_desc = desc;
            subm.as_id = ass;
            db.as_submit.Add(subm);
            int a = db.SaveChanges();
            return RedirectToAction("Index", "User");
        }
 













    }







}