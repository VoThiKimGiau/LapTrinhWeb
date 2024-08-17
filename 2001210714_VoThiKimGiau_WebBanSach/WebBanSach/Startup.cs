using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanSach.Identity;

[assembly: OwinStartup(typeof(WebBanSach.Startup))]

namespace WebBanSach
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRoles();
        }

        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MyDbContext()));

            var dbcontext = new MyDbContext();
            var userstore = new UserStoreIdentity(dbcontext);
            var userManager = new ManagerUserIdentity(userstore);

            if (!roleManager.RoleExists("Admin")) // Tạo Admin
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (userManager.FindByName("admin") == null)
            {
                var user = new User();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPass = "admin123";

                var ckUser = userManager.Create(user, userPass);
                if (ckUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
