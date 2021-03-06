﻿///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Nishanth Antony Satler       Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Nishanth Antony Satler        25-July-2018       Class Created
///-----------------------------------------------------------------

using DalIntern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DalIntern.Controllers
{
    public class PositionController : Controller
    {        
        public async Task<ActionResult> Index(string id = null)
        {
            if (id == null)
            {
                ViewBag.Title = "No details found";
                return RedirectToActionPermanent("Index","Explore",new { });
            }

            PositionModel viewModel = null;
            var userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            using (ExploreDbContext context = new ExploreDbContext())
            {
                viewModel = context.Position.Where(x => x.id == id).FirstOrDefault();
                viewModel.company = context.Company.Where(x => x.id == viewModel.companyid).FirstOrDefault();
                List<ReviewModel> reviews = null;
                var searchString = Request.Form["searchMessage"];
                if(string.IsNullOrWhiteSpace(searchString))
                {
                    reviews = context.Review.Where(x => x.PositionId == id).ToList();
                }
                else
                {
                    reviews = context.Review.Where(x => x.PositionId == id && x.reviewmessage.Contains(searchString)).ToList();
                }
               
                foreach (var review in reviews)
                {
                    review.Owner = await userManager.FindByIdAsync(review.UserId);
                }
            }
            return View(viewModel);
        }

        public async Task<ActionResult> AddReview(AddReviewViewModel model)
        {
            try
            {
                if (model != null)
                {
                    using (ExploreDbContext context = new ExploreDbContext())
                    {
                        // Add the review to database
                        ReviewModel newReview = new ReviewModel();
                        newReview.createddate = DateTime.Now;
                        newReview.dislikes = 0; newReview.likes = 0;
                        newReview.overallrating = model.rating;
                        newReview.id = Convert.ToString(Guid.NewGuid());
                        newReview.reviewmessage = model.review;
                        newReview.PositionId = model.id;
                        newReview.UserId = User.Identity.GetUserId();

                        context.AddReviewModel(newReview);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToActionPermanent("Index", new { id = model.id })
;
        }

        [HttpPost]
        public async Task<ActionResult> LikeReview(string id)
        {
            if (id == null)
                return Json(null);
            try
            {
                id = id.Trim();
                using (ExploreDbContext dbContext = new ExploreDbContext())
                {
                    var review =  dbContext.Review.Where(x => x.id == id).FirstOrDefault();
                    if(review!=null)
                    {
                        review.likes++;
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
                return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DislikeReview(string id)
        {
            if (id == null)
                return Json(null);
            try
            {
                id = id.Trim();
                using (ExploreDbContext dbContext = new ExploreDbContext())
                {
                    var review = dbContext.Review.Where(x => x.id == id).FirstOrDefault();
                    if (review != null)
                    {
                        review.dislikes++;
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}