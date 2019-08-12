using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Models;

namespace RestaurantReviews.Controllers
{
    public class RestaurantsController : Controller
    {
        private MyEntities db = new MyEntities();

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.RESTAURANTS.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANT rESTAURANT = db.RESTAURANTS.Find(id);
            if (rESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANT);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location")] RESTAURANT rESTAURANT)
        {
            if (ModelState.IsValid)
            {
                db.RESTAURANTS.Add(rESTAURANT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rESTAURANT);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANT rESTAURANT = db.RESTAURANTS.Find(id);
            if (rESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANT);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location")] RESTAURANT rESTAURANT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESTAURANT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rESTAURANT);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANT rESTAURANT = db.RESTAURANTS.Find(id);
            if (rESTAURANT == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANT);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESTAURANT rESTAURANT = db.RESTAURANTS.Find(id);
            db.RESTAURANTS.Remove(rESTAURANT);
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
