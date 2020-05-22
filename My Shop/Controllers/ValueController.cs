using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Controllers
{
    public class ValueController : Controller
    {
        // GET: Value
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}