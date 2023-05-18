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
    public class st_feesController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: st_fees
        public ActionResult Index()
        {
            var st_fees = db.st_fees.Include(s => s.std_info);
            return View(st_fees.ToList());
        }

        // GET: st_fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            st_fees st_fees = db.st_fees.Find(id);
            if (st_fees == null)
            {
                return HttpNotFound();
            }
            return View(st_fees);
        }

        // GET: st_fees/Create
        public ActionResult Create()
        {
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_cpass");
            return View();
        }

        // POST: st_fees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "f_id,f_date,f_fees,s_id")] st_fees st_fees , string f_month)
        {
            if (ModelState.IsValid)
            {
                st_fees.f_month = f_month;
                db.st_fees.Add(st_fees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_cpass", st_fees.s_id);
            return View(st_fees);
        }

        // GET: st_fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            st_fees st_fees = db.st_fees.Find(id);
            if (st_fees == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", st_fees.s_id);
            return View(st_fees);
        }

        // POST: st_fees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "f_id,f_month,f_date,f_fees,s_id")] st_fees st_fees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(st_fees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", st_fees.s_id);
            return View(st_fees);
        }

        // GET: st_fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            st_fees st_fees = db.st_fees.Find(id);
            if (st_fees == null)
            {
                return HttpNotFound();
            }
            return View(st_fees);
        }

        // POST: st_fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            st_fees st_fees = db.st_fees.Find(id);
            db.st_fees.Remove(st_fees);
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
