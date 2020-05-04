using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Create()
        {
            return View(new CreateProductViewModel() { groups = db.Groups });
        }
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            string filename = "";
            string path = Server.MapPath("~") + "Files\\ProductPicture\\";
            foreach (var item in files)
            {
                filename = path + DateTime.Now.GetHashCode() + item.FileName;
                item.SaveAs(filename);

                model.product.ProductFiles.Add(new ProductFile(){ LocationFile=filename});

            }

            return View();
        }
    }
}