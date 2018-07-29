using DalIntern.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Nishanth Antony Satler       Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Nishanth Antony Satler        25-July-2018       Class Created
///-----------------------------------------------------------------
using Microsoft.Owin;
using Owin;
using System.Web.Configuration;

[assembly: OwinStartupAttribute(typeof(DalIntern.Startup))]
namespace DalIntern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createAdminUser();
        }


        /**private void CreateAdminUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if(!roleManager.RoleExists(WebConfigurationManager.AppSettings["AdminRoleName"]))
            {
                // Create Role
                var newRole = new IdentityRole();
                newRole.Name = WebConfigurationManager.AppSettings["AdminRoleName"];
                roleManager.Create(newRole);

                // Create Admin User
                var newuser = new ApplicationUser();
                newuser.UserName = WebConfigurationManager.AppSettings["adminUserName"];
                newuser.Email = WebConfigurationManager.AppSettings["adminUserName"];
                var result = UserManager.Create(newuser, WebConfigurationManager.AppSettings["adminPassword"]);
                //Add default User to Role Admin   
                if (result.Succeeded)
                {
                    var result1 = UserManager.AddToRole(newuser.Id, WebConfigurationManager.AppSettings["AdminRoleName"]);
                }

            }
        }**/
    }
}
