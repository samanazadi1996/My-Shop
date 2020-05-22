using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Areas.Admin.Controllers
{
    public class ValueController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Banner()
        {
            var model = db.values.Where(p => p.Name == "BannerTop" || p.Name == "Banner1*1" || p.Name == "Banner2*1");
            return View(model);
        }
        public ActionResult _CreateBanner(string type)
        {
            ViewBag.name = type;
            return PartialView();
        }
        public ActionResult _DetailsBanner(int id)
        {
            var model = db.values.Find(id);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult CreateBanner(Value value, HttpPostedFileBase file)
        {
            string mappath = Server.MapPath("~") + "Files\\BannerPicture\\";
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
            string path = mappath + filename;
            file.SaveAs(path);
            value.Text = "/Files/BannerPicture/" + filename;
            value.DateTime = DateTime.Now;
            db.values.Add(value);
            db.SaveChanges();
            return RedirectToAction("Banner");
        }
        public ActionResult _DeleteBanner(int id)
        {
            var model = db.values.Find(id);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult ConfirmDeleteBanner(int Id)
        {
            var banner = db.values.Find(Id);
            db.values.Remove(banner);
            db.SaveChanges();
            return RedirectToAction("Banner");
        }
    }
}