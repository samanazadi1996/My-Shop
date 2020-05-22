using Common;
using Models;
using My_Shop.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Create()
        {
            ViewBag.Brands = new SelectList(db.brands.ToList(), "Id", "Name");
            return View(new CreateProductViewModel() { groups = db.Groups });
        }
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            string filename = "", path = "";
            string mappath = Server.MapPath("~") + "Files\\ProductPicture\\";
            var temp = model.product;
            temp.Datetime = DateTime.Now;
            temp.userId = 1;
            foreach (var item in files)
            {
                filename = DateTime.Now.GetHashCode() + item.FileName;
                path = mappath + filename;
                item.InputStream.ResizeImage(600, 900, path, ImageUploader.ImageComperssion.Normal);
                temp.ProductFiles.Add(new ProductFile() { LocationFile = "/Files/ProductPicture/" + filename });
            }
            db.products.Add(temp);
            db.SaveChanges();
            ViewBag.Brands = new SelectList(db.brands.ToList(), "Id", "Name");
            return View(new CreateProductViewModel() { groups = db.Groups });
        }
    }
}