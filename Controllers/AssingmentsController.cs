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
    public class AssingmentsController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: Assingments
        public ActionResult Index()
        {
            var assingments = db.Assingments.Include(a => a.batch).Include(a => a.st_subj);
            return View(assingments.ToList());
        }

        // GET: Assingments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assingment assingment = db.Assingments.Find(id);
            if (assingment == null)
            {
                return HttpNotFound();
            }
            return View(assingment);
        }

        // GET: Assingments/Create
        public ActionResult Create()
        {
            ViewBag.as_batch = new SelectList(db.batches, "b_id", "b_code");
            ViewBag.as_sub = new SelectList(db.st_subj, "s_id", "s_sub");
            return View();
        }

        // POST: Assingments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "as_id,as_title,as_sub,as_batch,as_date,as_file,as_desc")] Assingment assingment,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string file_name = file.FileName.ToString();
                string path = "~/admAssingments/" + file_name;
                file.SaveAs(Server.MapPath(path));
                assingment.as_file = path;
                db.Assingments.Add(assingment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.as_batch = new SelectList(db.batches, "b_id", "b_code", assingment.as_batch);
            ViewBag.as_sub = new SelectList(db.st_subj, "s_id", "s_sub", assingment.as_sub);
            return View(assingment);
        }

        // GET: Assingments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assingment assingment = db.Assingments.Find(id);
            if (assingment == null)
            {
                return HttpNotFound();
            }
            ViewBag.as_batch = new SelectList(db.batches, "b_id", "b_code", assingment.as_batch);
            ViewBag.as_sub = new SelectList(db.st_subj, "s_id", "s_sub", assingment.as_sub);
            return View(assingment);
        }

        // POST: Assingments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "as_id,as_title,as_sub,as_batch,as_date,as_file,as_desc")] Assingment assingment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assingment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.as_batch = new SelectList(db.batches, "b_id", "b_code", assingment.as_batch);
            ViewBag.as_sub = new SelectList(db.st_subj, "s_id", "s_sub", assingment.as_sub);
            return View(assingment);
        }

        // GET: Assingments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assingment assingment = db.Assingments.Find(id);
            if (assingment == null)
            {
                return HttpNotFound();
            }
            return View(assingment);
        }

        // POST: Assingments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assingment assingment = db.Assingments.Find(id);
            db.Assingments.Remove(assingment);
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
