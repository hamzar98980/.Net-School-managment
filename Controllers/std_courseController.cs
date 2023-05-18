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
    public class std_courseController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: std_course
        public ActionResult Index()
        {
            return View(db.std_course.ToList());
        }

        // GET: std_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_course std_course = db.std_course.Find(id);
            if (std_course == null)
            {
                return HttpNotFound();
            }
            return View(std_course);
        }

        // GET: std_course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: std_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "c_id,c_name,c_fees,c_img,c_desc")] std_course std_course , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string file_name = file.FileName.ToString();
                string path = "~/courseimg/" + file_name;
                file.SaveAs(Server.MapPath(path));
                std_course.c_img = path;
                db.std_course.Add(std_course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(std_course);
        }

        // GET: std_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_course std_course = db.std_course.Find(id);
            if (std_course == null)
            {
                return HttpNotFound();
            }
            return View(std_course);
        }

        // POST: std_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "c_id,c_name,c_fees,c_img,c_desc")] std_course std_course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(std_course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(std_course);
        }

        // GET: std_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_course std_course = db.std_course.Find(id);
            if (std_course == null)
            {
                return HttpNotFound();
            }
            return View(std_course);
        }

        // POST: std_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            std_course std_course = db.std_course.Find(id);
            db.std_course.Remove(std_course);
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
