using Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Controllers
{
    public class HomeController : Controller
    {
       private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}