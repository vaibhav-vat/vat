using RestaurantReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace RestaurantReviews.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MyEntities db = new MyEntities();
        public ActionResult Home()
        {

            var dISHES_REVIEWS = db.DISHES_REVIEWS.Include(r => r.RESTAURANT).Include(u => u.USER);
            return View(dISHES_REVIEWS.ToList());
           
        }

        public ActionResult RestroReviews()
        {
            ViewBag.Message = "Select Any One";

            return View();
        }

      
    }
}