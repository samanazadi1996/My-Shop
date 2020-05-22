using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Areas.Admin.Controllers
{
    public class GroupController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var model = db.Groups;
            return View(model);
        }

        [AjaxOnly]
        [HttpPost]
        public string DeleteGroup(int id)
        {
            var grop = db.Groups.Find(id);
            if (!db.Groups.Any(p => p.targetId == grop.Id))
            {
                db.Groups.Remove(grop);
                db.SaveChanges();
            }
            ViewData["id"] = "targetId";
            ViewData["name"] = "targetId";

            var tmp = this.RenderPartialToString("_GroupList", db.Groups);
            return tmp;

        }

        [AjaxOnly]
        [HttpPost]
        public string AddGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
            }
            ViewData["id"] = "targetId";
            ViewData["name"] = "targetId";
            var tmp = this.RenderPartialToString("_GroupList", db.Groups);
            return tmp;
        }

        [AjaxOnly]
        [HttpPost]
        public string EditGroup(Group group)
        {
            db.Entry(group).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewData["id"] = "targetId";
            ViewData["name"] = "targetId";
            var model = this.RenderPartialToString("_GroupList", db.Groups);
            return model;
        }

    }
}