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