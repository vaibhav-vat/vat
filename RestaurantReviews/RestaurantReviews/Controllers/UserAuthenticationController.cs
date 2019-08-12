using RestaurantReviews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RestaurantReviews.Controllers
{
    public class UserAuthenticationController : Controller
    {
        MyEntities myDBContext = new MyEntities();
        

        public ActionResult LogIn()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string Uname,string Upassword)
        {
            var Data = myDBContext.USERS.Where(u => u.UserName == Uname && u.Password == Upassword).Select(s => s).ToList();
           
          
            if (Data.Count==0)
            {
               
                //string msg = "Wrong Credentials";
                ViewBag.Message = "Wrong Credentials";
               return View();
            }
            FormsAuthentication.SetAuthCookie(Data.ElementAt(0).Name, false);
            ViewBag.Message = "";
            return RedirectToAction("Home", "Home");
        }
     

        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,UserName,Password,Name,Location")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                myDBContext.USERS.Add(uSER);
                myDBContext.SaveChanges();
                return RedirectToAction("LogIn");
            }

            return View(uSER);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }


    }
}