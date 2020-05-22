using Common;
using Models;
using My_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var temp = model.user;
                temp.Password = temp.Password.Encrypt();
                temp.Status = StatusTypeUser.Active;
                temp.Roles = "user";
                temp.DateOfBirth = model.user.DateOfBirth.ToMiladiDate();
                temp.Addresses.Add(model.address);
                db.Users.Add(temp);
                db.SaveChanges();
                return View();
            }
            return View(model);


        }
    }
}