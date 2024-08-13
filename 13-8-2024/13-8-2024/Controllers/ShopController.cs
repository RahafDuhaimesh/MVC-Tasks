using System.Collections.Generic;
using System.Web.Mvc;

namespace _13_8_2024.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index()
        {
            var products = Session["Products"] as List<string[]> ?? new List<string[]>();
            return View(products);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string name, string price, string imgURL)
        {
            var newItem = new string[] { name, price, imgURL };
            var products = Session["Products"] as List<string[]> ?? new List<string[]>();
            products.Add(newItem);
            Session["Products"] = products;
            return RedirectToAction("Index");
        }
    }
}
