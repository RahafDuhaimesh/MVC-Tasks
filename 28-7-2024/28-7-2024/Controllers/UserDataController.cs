using _28_7_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _28_7_2024.Controllers
{
    public class UserDataController : Controller
    {
        private Task5Entities1 db = new Task5Entities1();

        // Here we can see the table
        public ActionResult Index()
        {
            return View(db.UsersDatas.ToList());
        }

        public ActionResult Details(int id)
        {
          
            UsersData data = db.UsersDatas.Find(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FullName,Email,Password,Image")] UsersData data)
        {
            if (ModelState.IsValid)
            {
                db.UsersDatas.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            
            UsersData data = db.UsersDatas.Find(id);
            return View(data);
        }

      
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,Password,Image")] UsersData data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {

            UsersData data = db.UsersDatas.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersData data = db.UsersDatas.Find(id);
            db.UsersDatas.Remove(data);
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
