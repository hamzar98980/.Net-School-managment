using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using managment.Models;

namespace managment.Controllers
{
    public class std_infoController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: std_info


        public ActionResult Index()
        {

            var std_info = db.std_info.Include(s => s.batch);
            return View(std_info.ToList());
        }

        // GET: std_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_info std_info = db.std_info.Find(id);
            if (std_info == null)
            {
                return HttpNotFound();
            }
            return View(std_info);
        }

        // GET: std_info/Create
        public ActionResult Create()
        {
            ViewBag.s_batchid = new SelectList(db.batches, "b_id", "b_code");
            return View();
        }

        // POST: std_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s_id,s_name,s_relig,s_num,s_gender,s_email,s_pic,s_pass,s_cpass,s_batchid")] std_info std_info)
        {
            if (ModelState.IsValid)
            {
                db.std_info.Add(std_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s_batchid = new SelectList(db.batches, "b_id", "b_code", std_info.s_batchid);
            return View(std_info);
        }

        // GET: std_info/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_info std_info = db.std_info.Find(id);
            TempData["pic"] = std_info.s_pic;
            TempData.Keep();
            if (std_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_batchid = new SelectList(db.batches, "b_id", "b_code", std_info.s_batchid);
            return View(std_info);
        }

        // POST: std_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s_id,s_name,s_relig,s_num,s_gender,s_email,s_pic,s_pass,s_cpass,s_batchid")] std_info std_info , HttpPostedFileBase file)
        {
            std_info.s_pic = TempData["pic"].ToString();
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = file.FileName.ToString();
                    string path = "~/Uploads/" + filename;
                    file.SaveAs(Server.MapPath(path));
                    std_info.s_pic = path;
                }
                db.Entry(std_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_batchid = new SelectList(db.batches, "b_id", "b_code", std_info.s_batchid);
            return View(std_info);
        }

        // GET: std_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_info std_info = db.std_info.Find(id);
            if (std_info == null)
            {
                return HttpNotFound();
            }
            return View(std_info);
        }

        // POST: std_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            std_info std_info = db.std_info.Find(id);
            db.std_info.Remove(std_info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
