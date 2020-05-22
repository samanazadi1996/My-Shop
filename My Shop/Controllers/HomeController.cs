using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using My_Shop.ViewModels;

namespace My_Shop.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var temp = db.productCategories;
            var model = new HomeIndexViewModel()
            {
                Special = temp.Where(p => p.ProductType == ProductCategoryType.SpecialProduct).Select(p => p.Product),
                NewProduct = temp.Where(p => p.ProductType == ProductCategoryType.NewProduct).Select(p => p.Product),
                BstSeller = temp.Where(p => p.ProductType == ProductCategoryType.BestSellerProduct).Select(p => p.Product),
                Proposed = temp.Where(p => p.ProductType == ProductCategoryType.ProposedProduct).Select(p => p.Product),
                brands = db.brands,
                BannerTop=db.values.Where(p=>p.Name=="BannerTop"),
                Banner1_1=db.values.Where(p=>p.Name=="Banner1*1").Take(4),
                Banner2_1=db.values.Where(p=>p.Name=="Banner2*1").Take(2),
                EnableBanner = true
            };
            if (!model.NewProduct.Any())
                model.NewProduct = db.products.OrderByDescending(p => p.Datetime).Take(6);
            return View(model);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}