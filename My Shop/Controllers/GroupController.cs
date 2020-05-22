using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Controllers
{
    public class GroupController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult MenuGroups()
        {
            var model = db.Groups;
            return View(model);
        }

        public ActionResult _tab()
        {
            var group = db.Groups;
            var id = Convert.ToInt32( db.values.Single(p=>p.Name=="tab_1").Content);
            ViewBag.Groupname = group.Find(id).Name;
              var model= group.Where(p=>p.targetId.Value==id);
            return PartialView(model);
        }
    }
}