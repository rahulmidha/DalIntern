///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Mathew Zimola                  Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Mathew Zimola                 25-July-2018       Class Created
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DalIntern.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace DalIntern.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                ViewBag.Title = "No details found";
                return RedirectToActionPermanent("Index", "Explore", new object { });
            }
            else
            {
                //Retrieve the Company from Database
                CompanyModel getCompany = null;

                using (ExploreDbContext context = new ExploreDbContext())
                {
                    getCompany = context.Company.Where(x => x.id.Equals(id)).FirstOrDefault();

                    //Get the Relevant Job Positions
                    IList<PositionModel> companyPositions = context.Position.Where(x => x.companyid == id).ToList();
                    getCompany.Positions = companyPositions != null ? companyPositions : new List<PositionModel>();
                }

                return View(getCompany);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(CompanyViewModel model)
        {

            try
            {
                if(model!=null)
                {
                    ExploreDbContext dbContext = new ExploreDbContext();

                    // Create Job Position
                    PositionModel jobPosition = new PositionModel();
                    jobPosition.companyid = model.id;  // Associate the Company for the position

                    jobPosition.id = Convert.ToString(Guid.NewGuid());
                    jobPosition.overallrating = model.rating;
                    jobPosition.positionname = model.PositionName;
                    jobPosition.totalrevies = 1;

                    dbContext.AddPositionModel(jobPosition);

                    ReviewModel reviewMessage = new ReviewModel();
                    reviewMessage.id = Convert.ToString(Guid.NewGuid());
                    reviewMessage.PositionId = jobPosition.id;
                    reviewMessage.createddate = DateTime.Now;
                    reviewMessage.likes = 0; reviewMessage.dislikes = 0;
                    reviewMessage.reviewmessage = model.review;
                    reviewMessage.UserId = User.Identity.GetUserId();

                    dbContext.AddReviewModel(reviewMessage);
                    await dbContext.SaveChangesAsync();                   
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToActionPermanent("Index",new {id=model.id });
        }

    }
}