using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var model = db.brands;
            return View(model);
        }
        public ActionResult Create(Brand model, HttpPostedFileBase File)
        {
            string mappath = Server.MapPath("~") + "Files\\BrandPicture\\";
            string filename = DateTime.Now.GetHashCode() + File.FileName;

            string path = mappath + filename;
            File.InputStream.ResizeImage(60, 60, path, ImageUploader.ImageComperssion.Normal);
            model.Image = "/Files/BrandPicture/" + filename;
            db.brands.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}