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
    public class parent_infoController : Controller
    {
        private schoolmanage db = new schoolmanage();

        // GET: parent_info
        public ActionResult Index()
        {
            var parent_info = db.parent_info.Include(p => p.std_info);
            return View(parent_info.ToList());
        }

        // GET: parent_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parent_info parent_info = db.parent_info.Find(id);
            if (parent_info == null)
            {
                return HttpNotFound();
            }
            return View(parent_info);
        }

        // GET: parent_info/Create
        public ActionResult Create()
        {
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name");
            return View();
        }

        // POST: parent_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "par_Id,f_name,f_contact,m_name,m_contact,f_cnic,f_email,s_id")] parent_info parent_info)
        {
            if (ModelState.IsValid)
            {
                db.parent_info.Add(parent_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", parent_info.s_id);
            return View(parent_info);
        }

        // GET: parent_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parent_info parent_info = db.parent_info.Find(id);
            if (parent_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", parent_info.s_id);
            return View(parent_info);
        }

        // POST: parent_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "par_Id,f_name,f_contact,m_name,m_contact,f_cnic,f_email,s_id")] parent_info parent_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parent_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_id = new SelectList(db.std_info, "s_id", "s_name", parent_info.s_id);
            return View(parent_info);
        }

        // GET: parent_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parent_info parent_info = db.parent_info.Find(id);
            if (parent_info == null)
            {
                return HttpNotFound();
            }
            return View(parent_info);
        }

        // POST: parent_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parent_info parent_info = db.parent_info.Find(id);
            db.parent_info.Remove(parent_info);
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
