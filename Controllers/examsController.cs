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
    public class examsController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: exams
        public ActionResult Index()
        {
            var exams = db.exams.Include(e => e.batch).Include(e => e.st_subj);
            return View(exams.ToList());
        }

        // GET: exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: exams/Create
        public ActionResult Create()
        {
            ViewBag.e_batch = new SelectList(db.batches, "b_id", "b_code");
            ViewBag.e_subj = new SelectList(db.st_subj, "s_id", "s_sub");
            return View();
        }

        // POST: exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s_id,e_date,e_subj,e_batch,est_time,end_time,e_marks")] exam exam,string e_type)
        {
            if (ModelState.IsValid)
            {
                exam.e_type = e_type;
                db.exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.e_batch = new SelectList(db.batches, "b_id", "b_code", exam.e_batch);
            ViewBag.e_subj = new SelectList(db.st_subj, "s_id", "s_sub", exam.e_subj);
            return View(exam);
        }

        // GET: exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.e_batch = new SelectList(db.batches, "b_id", "b_code", exam.e_batch);
            ViewBag.e_subj = new SelectList(db.st_subj, "s_id", "s_sub", exam.e_subj);
            return View(exam);
        }

        // POST: exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s_id,e_type,e_date,e_subj,e_batch,est_time,end_time,e_marks")] exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.e_batch = new SelectList(db.batches, "b_id", "b_code", exam.e_batch);
            ViewBag.e_subj = new SelectList(db.st_subj, "s_id", "s_sub", exam.e_subj);
            return View(exam);
        }

        // GET: exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exam exam = db.exams.Find(id);
            db.exams.Remove(exam);
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
