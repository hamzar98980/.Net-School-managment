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
    public class teacher_batchController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: teacher_batch
        public ActionResult Index()
        {
            var teacher_batch = db.teacher_batch.Include(t => t.batch).Include(t => t.teacher_info);
            return View(teacher_batch.ToList());
        }

        // GET: teacher_batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_batch teacher_batch = db.teacher_batch.Find(id);
            if (teacher_batch == null)
            {
                return HttpNotFound();
            }
            return View(teacher_batch);
        }

        // GET: teacher_batch/Create
        public ActionResult Create()
        {
            ViewBag.bt_id = new SelectList(db.batches, "b_id", "b_code");
            ViewBag.tb_id = new SelectList(db.teacher_info, "t_id", "t_name");
            return View();
        }

        // POST: teacher_batch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "t_batch,bt_id,tb_id")] teacher_batch teacher_batch)
        {
            if (ModelState.IsValid)
            {
                db.teacher_batch.Add(teacher_batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bt_id = new SelectList(db.batches, "b_id", "b_code", teacher_batch.bt_id);
            ViewBag.tb_id = new SelectList(db.teacher_info, "t_id", "t_name", teacher_batch.tb_id);
            return View(teacher_batch);
        }

        // GET: teacher_batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_batch teacher_batch = db.teacher_batch.Find(id);
            if (teacher_batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.bt_id = new SelectList(db.batches, "b_id", "b_code", teacher_batch.bt_id);
            ViewBag.tb_id = new SelectList(db.teacher_info, "t_id", "t_name", teacher_batch.tb_id);
            return View(teacher_batch);
        }

        // POST: teacher_batch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "t_batch,bt_id,tb_id")] teacher_batch teacher_batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher_batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bt_id = new SelectList(db.batches, "b_id", "b_code", teacher_batch.bt_id);
            ViewBag.tb_id = new SelectList(db.teacher_info, "t_id", "t_name", teacher_batch.tb_id);
            return View(teacher_batch);
        }

        // GET: teacher_batch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_batch teacher_batch = db.teacher_batch.Find(id);
            if (teacher_batch == null)
            {
                return HttpNotFound();
            }
            return View(teacher_batch);
        }

        // POST: teacher_batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacher_batch teacher_batch = db.teacher_batch.Find(id);
            db.teacher_batch.Remove(teacher_batch);
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
