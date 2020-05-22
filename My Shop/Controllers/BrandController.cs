using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Controllers
{
    public class BrandController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult MenuBrands()
        {
            var model = db.brands;
            return View(model);
        }
    }
}