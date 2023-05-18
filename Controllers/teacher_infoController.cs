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
    public class teacher_infoController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: teacher_info
        public ActionResult Index()
        {
            return View(db.teacher_info.ToList());
        }

        // GET: teacher_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_info teacher_info = db.teacher_info.Find(id);
            if (teacher_info == null)
            {
                return HttpNotFound();
            }
            return View(teacher_info);
        }

        // GET: teacher_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teacher_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "t_id,t_name,t_email,t_salary")] teacher_info teacher_info)
        {
            if (ModelState.IsValid)
            {
                db.teacher_info.Add(teacher_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher_info);
        }

        // GET: teacher_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_info teacher_info = db.teacher_info.Find(id);
            if (teacher_info == null)
            {
                return HttpNotFound();
            }
            return View(teacher_info);
        }

        // POST: teacher_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "t_id,t_name,t_email,t_salary")] teacher_info teacher_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher_info);
        }

        // GET: teacher_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_info teacher_info = db.teacher_info.Find(id);
            if (teacher_info == null)
            {
                return HttpNotFound();
            }
            return View(teacher_info);
        }

        // POST: teacher_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacher_info teacher_info = db.teacher_info.Find(id);
            db.teacher_info.Remove(teacher_info);
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
