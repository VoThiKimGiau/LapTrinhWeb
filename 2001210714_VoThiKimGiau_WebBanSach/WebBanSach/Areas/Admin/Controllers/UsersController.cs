using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Identity;

namespace WebBanSach.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            MyDbContext db = new MyDbContext();
            List<User> users = db.Users.ToList();

            return View(users);
        }
    }
}