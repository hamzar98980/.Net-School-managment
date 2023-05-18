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
    public class std_addController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: std_add
        public ActionResult Index()
        {
            var std_add = db.std_add.Include(s => s.std_info);
            return View(std_add.ToList());
        }

        // GET: std_add/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_add std_add = db.std_add.Find(id);
            if (std_add == null)
            {
                return HttpNotFound();
            }
            return View(std_add);
        }

        // GET: std_add/Create
        public ActionResult Create()
        {
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name");
            return View();
        }

        // POST: std_add/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s_add,s_city,p_o_b,d_o_b,s_address,s_id")] std_add std_add)
        {
            if (ModelState.IsValid)
            {
                db.std_add.Add(std_add);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", std_add.s_id);
            return View(std_add);
        }

        // GET: std_add/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_add std_add = db.std_add.Find(id);
            if (std_add == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", std_add.s_id);
            return View(std_add);
        }

        // POST: std_add/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s_add,s_city,p_o_b,d_o_b,s_address,s_id")] std_add std_add)
        {
            if (ModelState.IsValid)
            {
                db.Entry(std_add).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", std_add.s_id);
            return View(std_add);
        }

        // GET: std_add/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_add std_add = db.std_add.Find(id);
            if (std_add == null)
            {
                return HttpNotFound();
            }
            return View(std_add);
        }

        // POST: std_add/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            std_add std_add = db.std_add.Find(id);
            db.std_add.Remove(std_add);
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
