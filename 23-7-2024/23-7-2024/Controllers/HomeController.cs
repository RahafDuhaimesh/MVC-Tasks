using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace _23_7_2024.Controllers
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

        public ActionResult ShowFeedbacks(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            ViewBag.Gender = form["gender"];
            ViewBag.FeedbackType = form["FeedbackType"];
            ViewBag.Feedback = form["Feedback"];
            return View();
        }
        [ActionName("ShowFeedbacks")]
        public ActionResult ShowFeedbacks()
        {
            return View();
        }
    }
}