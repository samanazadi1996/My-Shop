using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace My_Shop.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var model = db.products.Find(id);
            return View(model);
        }
        public ActionResult _Product(int id)
        {
            var product = db.products.Find(id);
            return PartialView(product);
        }
        public ActionResult _ListProduct(int id)
        {
            var product = db.Groups.Find(id).Products.OrderByDescending(p=>p.Datetime).Take(6);
            var t = product.Count();
            return PartialView(product);
        }
    }
}