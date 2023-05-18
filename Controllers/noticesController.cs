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
    public class noticesController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: notices
        public ActionResult Index()
        {
            var notices = db.notices.Include(n => n.batch);
            return View(notices.ToList());
        }

        // GET: notices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice notice = db.notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // GET: notices/Create
        public ActionResult Create()
        {
            ViewBag.n_batch = new SelectList(db.batches, "b_id", "b_code");
            return View();
        }

        // POST: notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "n_id,n_title,n_date,n_batch,n_desc")] notice notice)
        {
            if (ModelState.IsValid)
            {
                db.notices.Add(notice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.n_batch = new SelectList(db.batches, "b_id", "b_code", notice.n_batch);
            return View(notice);
        }

        // GET: notices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice notice = db.notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            ViewBag.n_batch = new SelectList(db.batches, "b_id", "b_code", notice.n_batch);
            return View(notice);
        }

        // POST: notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "n_id,n_title,n_date,n_batch,n_desc")] notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.n_batch = new SelectList(db.batches, "b_id", "b_code", notice.n_batch);
            return View(notice);
        }

        // GET: notices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice notice = db.notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice notice = db.notices.Find(id);
            db.notices.Remove(notice);
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
