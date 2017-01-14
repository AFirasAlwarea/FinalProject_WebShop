using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject_WebShop.Models;

namespace FinalProject_WebShop.Controllers
{
    public class OrderRowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderRows
        public ActionResult Index()
        {
            return View(db.OrderRow.ToList());
        }

        // GET: OrderRows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRow orderRow = db.OrderRow.Find(id);
            if (orderRow == null)
            {
                return HttpNotFound();
            }
            return View(orderRow);
        }

        // GET: OrderRows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,ProductId,ProductPrice")] OrderRow orderRow)
        {
            if (ModelState.IsValid)
            {
                db.OrderRow.Add(orderRow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderRow);
        }

        // GET: OrderRows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRow orderRow = db.OrderRow.Find(id);
            if (orderRow == null)
            {
                return HttpNotFound();
            }
            return View(orderRow);
        }

        // POST: OrderRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,ProductId,ProductPrice")] OrderRow orderRow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderRow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderRow);
        }

        // GET: OrderRows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRow orderRow = db.OrderRow.Find(id);
            if (orderRow == null)
            {
                return HttpNotFound();
            }
            return View(orderRow);
        }

        // POST: OrderRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRow orderRow = db.OrderRow.Find(id);
            db.OrderRow.Remove(orderRow);
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
