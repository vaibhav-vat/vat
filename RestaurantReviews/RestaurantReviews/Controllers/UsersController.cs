//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using RestaurantReviews.Models;

//namespace RestaurantReviews.Controllers
//{
//    public class UsersController : Controller
//    {
//        private MyEntities db = new MyEntities();

//        // GET: Users
//        public ActionResult Index()
//        {
//            return View(db.USERS.ToList());
//        }

//        // GET: Users/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            USER uSER = db.USERS.Find(id);
//            if (uSER == null)
//            {
//                return HttpNotFound();
//            }
//            return View(uSER);
//        }

       
      

//        // GET: Users/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            USER uSER = db.USERS.Find(id);
//            if (uSER == null)
//            {
//                return HttpNotFound();
//            }
//            return View(uSER);
//        }

//        // POST: Users/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,UserName,Password,Name,Location")] USER uSER)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(uSER).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(uSER);
//        }

//        // GET: Users/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            USER uSER = db.USERS.Find(id);
//            if (uSER == null)
//            {
//                return HttpNotFound();
//            }
//            return View(uSER);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            USER uSER = db.USERS.Find(id);
//            db.USERS.Remove(uSER);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
