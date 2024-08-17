using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;
using WebBanSach.ViewModel;
using WebBanSach.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebBanSach.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if (ModelState.IsValid)
            {
                var dbcontext = new MyDbContext();
                var userstore = new UserStoreIdentity(dbcontext);
                var usermanager = new ManagerUserIdentity(userstore);
                var passhash = Crypto.HashPassword(rvm.Password);
                var user = new User()
                {
                    UserName = rvm.UserName,
                    PasswordHash = passhash,
                    Email = rvm.Email,
                    PhoneNumber = rvm.PhoneNumber,
                    Address = rvm.Address,
                    BirthDay = rvm.DateOfBirth
                };
                IdentityResult identityResult = usermanager.Create(user);
                if (identityResult.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = usermanager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }    
        
        [HttpPost]       
        public ActionResult Login(LoginVM loginVM)
        {
            var dbcontext = new MyDbContext();
            var userstore = new UserStoreIdentity(dbcontext);
            var usermanager = new ManagerUserIdentity(userstore);
            var user = usermanager.Find(loginVM.UserName, loginVM.Password);

            if(user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = usermanager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if(usermanager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin"});
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }    
            else
            {
                ModelState.AddModelError("MyError", "Invalid UserName and Password");
                return View();
            }    
        }

        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}