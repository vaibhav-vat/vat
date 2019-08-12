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
    public class DishesReviewsController : Controller
    {
        private MyEntities db = new MyEntities();

        // GET: DishesReviews
        public ActionResult Index()
        {
            var dISHES_REVIEWS = db.DISHES_REVIEWS.Include(d => d.RESTAURANT).Include(d => d.USER);
            return View(dISHES_REVIEWS.ToList());
        }

        // GET: DishesReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISHES_REVIEWS dISHES_REVIEWS = db.DISHES_REVIEWS.Find(id);
            if (dISHES_REVIEWS == null)
            {
                return HttpNotFound();
            }
            return View(dISHES_REVIEWS);
        }

        // GET: DishesReviews/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.RESTAURANTS, "Id", "Name");
            ViewBag.UserId = new SelectList(db.USERS, "Id", "UserName");
            return View();
        }

        // POST: DishesReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RestaurantId,UserId,Name,Quality,Taste,Price,Service,Comment")] DISHES_REVIEWS dISHES_REVIEWS)
        {
            if (ModelState.IsValid)
            {
                db.DISHES_REVIEWS.Add(dISHES_REVIEWS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.RESTAURANTS, "Id", "Name", dISHES_REVIEWS.RestaurantId);
            ViewBag.UserId = new SelectList(db.USERS, "Id", "UserName", dISHES_REVIEWS.UserId);
            return View(dISHES_REVIEWS);
        }

        // GET: DishesReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISHES_REVIEWS dISHES_REVIEWS = db.DISHES_REVIEWS.Find(id);
            if (dISHES_REVIEWS == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.RESTAURANTS, "Id", "Name", dISHES_REVIEWS.RestaurantId);
            ViewBag.UserId = new SelectList(db.USERS, "Id", "Name", dISHES_REVIEWS.UserId);
            return View(dISHES_REVIEWS);
        }

        // POST: DishesReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RestaurantId,UserId,Name,Quality,Taste,Price,Service,Comment")] DISHES_REVIEWS dISHES_REVIEWS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISHES_REVIEWS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.RESTAURANTS, "Id", "Name", dISHES_REVIEWS.RestaurantId);
            ViewBag.UserId = new SelectList(db.USERS, "Id", "UserName", dISHES_REVIEWS.UserId);
            return View(dISHES_REVIEWS);
        }

        // GET: DishesReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISHES_REVIEWS dISHES_REVIEWS = db.DISHES_REVIEWS.Find(id);
            if (dISHES_REVIEWS == null)
            {
                return HttpNotFound();
            }
            return View(dISHES_REVIEWS);
        }

        // POST: DishesReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISHES_REVIEWS dISHES_REVIEWS = db.DISHES_REVIEWS.Find(id);
            db.DISHES_REVIEWS.Remove(dISHES_REVIEWS);
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
