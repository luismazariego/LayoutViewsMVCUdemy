using System;
using System.Threading.Tasks;
using EFDbFirstApproachExample.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(EFDbFirstApproachExample.Startup1))]

namespace EFDbFirstApproachExample
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            //Create admin role
            #region Create Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
            }
            #endregion

            //Create Admin User
            #region Create Admin User
            if (userManager.FindByName("admin") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };
                string userPassword = "admin123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            #endregion

            //Create Manager Role
            #region Create Manager Role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole {Name = "Manager"};
                roleManager.Create(role);
            }
            #endregion

            //Create Manager User
            #region Create Manager User
            if (userManager.FindByName("manager") == null)
            {
                var user = new ApplicationUser {UserName = "manager", Email = "manager@gmail.com"};
                string userPassword = "manager123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }
            #endregion

            //Create Customer Role
            #region Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
            #endregion
        }
    }
}
