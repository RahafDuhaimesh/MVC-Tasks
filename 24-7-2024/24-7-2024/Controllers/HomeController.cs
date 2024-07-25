using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _24_7_2024.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult ContactForm(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            ViewBag.Gender = form["gender"];
            ViewBag.FeedbackType = form["FeedbackType"];
            ViewBag.Feedback = form["Feedback"];
            return View();
        }

        [HttpPost]
        [ActionName("ContactForm")]
        public ActionResult ShowFeedbacks(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            ViewBag.Gender = form["gender"];
            ViewBag.FeedbackType = form["FeedbackType"];
            ViewBag.Feedback = form["Feedback"];
            return View();
        }

        public ActionResult Login(FormCollection form)
        {
            ViewBag.Email = form["email"];
            ViewBag.Password = form["password"];

            string[] user = { "Rahaf@gmail.com", "123" };
            if (user[0] == ViewBag.Email && user[1] == ViewBag.Password)
            {
                Session["LoggedUser"] = ViewBag.Email;
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid User!";
                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult ProfilePage()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("HomePage", "Home");
        }

    }
}
