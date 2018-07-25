///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Niravsinh Jadeja                 Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Niravsinh Jadeja              25-July-2018       Class Created
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DalIntern.Models;
using Microsoft.AspNet.Identity;

namespace DalIntern.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        const string unknown = "unknown";
        // GET: Profile
        public ActionResult Index(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    //Get the Current user record from Database
                    var currentId = User.Identity.GetUserId();
                    var user = dbContext.Users.Where(x => x.Id == currentId).FirstOrDefault();
                    if(user!=null)
                    {
                        ProfileViewModel viewModel = new ProfileViewModel()
                        {
                            Id = user.Id,
                            DateOfBirth = user.DateOfBirth != null ? user.DateOfBirth.ToString() : unknown,
                            FirstName = user.FirstName,
                            LastName  = user.LastName,
                            Email = user.Email,
                            EmailConfirmed = user.EmailConfirmed?"Yes":"No",
                            Anonymous = user.Anonymous ? "Yes" : "No",
                            Gender = user.Gender=="M"?"Male":"Female",
                            UserName = user.UserName,
                            PhoneNumber = user.PhoneNumber!=null? user.PhoneNumber.ToString():unknown                           
                        };
                        return View(viewModel);
                    }                   
                }
            }

            return View("Error", new HandleErrorInfo(new Exception("Access is denied."), string.Empty, string.Empty));
        }

        public ActionResult ShowProfile(string id)
        {

            if (!string.IsNullOrEmpty(id))
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var user = dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
                    if (user != null && user?.Anonymous == false)
                    {
                        ProfileViewModel viewModel = new ProfileViewModel()
                        {
                            Id = user.Id,
                            DateOfBirth = user.DateOfBirth != null ? user.DateOfBirth.ToString() : unknown,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            EmailConfirmed = user.EmailConfirmed ? "Yes" : "No",
                            Anonymous = user.Anonymous ? "Yes" : "No",
                            Gender = user.Gender == "M" ? "Male" : "Female",
                            UserName = user.UserName,
                            PhoneNumber = user.PhoneNumber != null ? user.PhoneNumber.ToString() : unknown
                        };
                        return View(viewModel);
                    }
                }
            }
            return View("Error", new HandleErrorInfo(new Exception("Access is denied."), nameof(ProfileController), "Show Profile"));
        }

    }
}