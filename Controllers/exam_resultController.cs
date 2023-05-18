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
    public class exam_resultController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: exam_result
        public ActionResult Index()
        {
            var exam_result = db.exam_result.Include(e => e.exam).Include(e => e.std_info).Include(e => e.st_subj);
            return View(exam_result.ToList());
        }

        // GET: exam_result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_result exam_result = db.exam_result.Find(id);
            if (exam_result == null)
            {
                return HttpNotFound();
            }
            return View(exam_result);
        }

        // GET: exam_result/Create
        public ActionResult Create()
        {
            ViewBag.en_id = new SelectList(db.exams, "s_id", "e_type");
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_cpass");
            ViewBag.et_id = new SelectList(db.st_subj, "s_id", "s_sub");
            return View();
        }

        // POST: exam_result/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "er_id,s_id,er_marks,er_per,er_grade,et_id,en_id,er_remarks")] exam_result exam_result)
        {
            if (ModelState.IsValid)
            {               
                db.exam_result.Add(exam_result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.en_id = new SelectList(db.exams, "s_id", "e_type", exam_result.en_id);
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_cpass", exam_result.s_id);
            ViewBag.et_id = new SelectList(db.st_subj, "s_id", "s_sub", exam_result.et_id);
            return View(exam_result);
        }

        // GET: exam_result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_result exam_result = db.exam_result.Find(id);
            if (exam_result == null)
            {
                return HttpNotFound();
            }
            ViewBag.en_id = new SelectList(db.exams, "s_id", "e_type", exam_result.en_id);
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_cpass", exam_result.s_id);
            ViewBag.et_id = new SelectList(db.st_subj, "s_id", "s_sub", exam_result.et_id);
            return View(exam_result);
        }

        // POST: exam_result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "er_id,s_id,er_marks,er_per,er_grade,et_id,en_id,er_remarks")] exam_result exam_result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.en_id = new SelectList(db.exams, "s_id", "e_type", exam_result.en_id);
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_cpass", exam_result.s_id);
            ViewBag.et_id = new SelectList(db.st_subj, "s_id", "s_sub", exam_result.et_id);
            return View(exam_result);
        }

        // GET: exam_result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_result exam_result = db.exam_result.Find(id);
            if (exam_result == null)
            {
                return HttpNotFound();
            }
            return View(exam_result);
        }

        // POST: exam_result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exam_result exam_result = db.exam_result.Find(id);
            db.exam_result.Remove(exam_result);
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
