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
    public class st_subjController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: st_subj
        public ActionResult Index()
        {
            return View(db.st_subj.ToList());
        }

        // GET: st_subj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            st_subj st_subj = db.st_subj.Find(id);
            if (st_subj == null)
            {
                return HttpNotFound();
            }
            return View(st_subj);
        }

        // GET: st_subj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: st_subj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s_id,s_sub,s_type")] st_subj st_subj, string sm_sub)
        {
            if (ModelState.IsValid)
            {
                st_subj.s_type = sm_sub;
                db.st_subj.Add(st_subj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(st_subj);
        }

        // GET: st_subj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            st_subj st_subj = db.st_subj.Find(id);
            if (st_subj == null)
            {
                return HttpNotFound();
            }
            return View(st_subj);
        }

        // POST: st_subj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s_id,s_sub,s_type")] st_subj st_subj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(st_subj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st_subj);
        }

        // GET: st_subj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            st_subj st_subj = db.st_subj.Find(id);
            if (st_subj == null)
            {
                return HttpNotFound();
            }
            return View(st_subj);
        }

        // POST: st_subj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            st_subj st_subj = db.st_subj.Find(id);
            db.st_subj.Remove(st_subj);
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
