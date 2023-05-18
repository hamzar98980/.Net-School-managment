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
    public class std_matController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: std_mat
        public ActionResult Index()
        {
            var std_mat = db.std_mat.Include(s => s.batch).Include(s => s.st_subj);
            return View(std_mat.ToList());
        }

        // GET: std_mat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_mat std_mat = db.std_mat.Find(id);
            if (std_mat == null)
            {
                return HttpNotFound();
            }
            return View(std_mat);
        }

        // GET: std_mat/Create
        public ActionResult Create()
        {
            ViewBag.sm_batch = new SelectList(db.batches, "b_id", "b_code");
            ViewBag.sm_subj = new SelectList(db.st_subj, "s_id", "s_sub");
            return View();
        }

        // POST: std_mat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sm_id,sm_subj,sm_desc,sm_file,sm_batch")] std_mat std_mat, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string filename = file.FileName.ToString();
                string path = "~/StudyM/" + filename;
                file.SaveAs(Server.MapPath(path));
                std_mat.sm_file = path;

                db.std_mat.Add(std_mat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sm_batch = new SelectList(db.batches, "b_id", "b_code", std_mat.sm_batch);
            ViewBag.sm_subj = new SelectList(db.st_subj, "s_id", "s_sub", std_mat.sm_subj);
            return View(std_mat);
        }

        // GET: std_mat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_mat std_mat = db.std_mat.Find(id);
            if (std_mat == null)
            {
                return HttpNotFound();
            }
            ViewBag.sm_batch = new SelectList(db.batches, "b_id", "b_code", std_mat.sm_batch);
            ViewBag.sm_subj = new SelectList(db.st_subj, "s_id", "s_sub", std_mat.sm_subj);
            return View(std_mat);
        }

        // POST: std_mat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sm_id,sm_subj,sm_desc,sm_file,sm_batch")] std_mat std_mat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(std_mat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sm_batch = new SelectList(db.batches, "b_id", "b_code", std_mat.sm_batch);
            ViewBag.sm_subj = new SelectList(db.st_subj, "s_id", "s_sub", std_mat.sm_subj);
            return View(std_mat);
        }

        // GET: std_mat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_mat std_mat = db.std_mat.Find(id);
            if (std_mat == null)
            {
                return HttpNotFound();
            }
            return View(std_mat);
        }

        // POST: std_mat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            std_mat std_mat = db.std_mat.Find(id);
            db.std_mat.Remove(std_mat);
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
