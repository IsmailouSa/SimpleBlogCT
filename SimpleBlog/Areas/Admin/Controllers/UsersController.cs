using SimpleBlog.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Models;
using NHibernate.Linq;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    [SelectedTabAttribute("users")]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = Database.Session.Query<User>().ToList(); //select * from users
            return View(new UsersIndex() { Users = users });
        }

        public ActionResult New()
        {
            return View(new UsersNew { });
        }
        [HttpPost]
        public ActionResult New(UsersNew form)
        {
            if (Database.Session.Query<User>().Any(u => u.Username == form.Username))
                ModelState.AddModelError("Username", "Username must be unique");
            if (!ModelState.IsValid)
                return View(form);
            var user = new User
            {
                Email = form.Email,
                Username = form.Username
            };
            user.SetPassword(form.Password);
            Database.Session.Save(user);

            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            return Content("Admin Area Users Controller List Action");
        }

        public ActionResult Edit(int id=0)
        {
            return Content("Admin Area Users Controller Edit Action with parameter : " + id.ToString());
        }
    }
}