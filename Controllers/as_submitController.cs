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
    public class as_submitController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: as_submit
        public ActionResult Index()
        {
            var as_submit = db.as_submit.Include(a => a.Assingment).Include(a => a.std_info);
            return View(as_submit.ToList());
        }

        // GET: as_submit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            as_submit as_submit = db.as_submit.Find(id);
            if (as_submit == null)
            {
                return HttpNotFound();
            }
            return View(as_submit);
        }

        // GET: as_submit/Create
        public ActionResult Create()
        {
            ViewBag.as_id = new SelectList(db.Assingments, "as_id", "as_title");
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name");
            return View();
        }

        // POST: as_submit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "su_id,s_id,su_submit,su_desc,as_id")] as_submit as_submit)
        {
            if (ModelState.IsValid)
            {
                db.as_submit.Add(as_submit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.as_id = new SelectList(db.Assingments, "as_id", "as_title", as_submit.as_id);
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", as_submit.s_id);
            return View(as_submit);
        }

        // GET: as_submit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            as_submit as_submit = db.as_submit.Find(id);
            if (as_submit == null)
            {
                return HttpNotFound();
            }
            ViewBag.as_id = new SelectList(db.Assingments, "as_id", "as_title", as_submit.as_id);
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", as_submit.s_id);
            return View(as_submit);
        }

        // POST: as_submit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "su_id,s_id,su_submit,su_desc,as_id")] as_submit as_submit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(as_submit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.as_id = new SelectList(db.Assingments, "as_id", "as_title", as_submit.as_id);
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", as_submit.s_id);
            return View(as_submit);
        }

        // GET: as_submit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            as_submit as_submit = db.as_submit.Find(id);
            if (as_submit == null)
            {
                return HttpNotFound();
            }
            return View(as_submit);
        }

        // POST: as_submit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            as_submit as_submit = db.as_submit.Find(id);
            db.as_submit.Remove(as_submit);
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
