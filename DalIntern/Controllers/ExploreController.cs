﻿///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Anudeep Buchhanagar          Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Anudeep Buchhanagari          25-July-2018       Class Created
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DalIntern.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RestSharp;

namespace DalIntern.Controllers
{
    [Authorize]
    public class ExploreController : Controller
    {

        public ActionResult Index(string searchstring = null)
        {
            //Create the Data Context Class
            ExploreDbContext dbContext = new ExploreDbContext();

            // Get the Top 10 Companies
            List<CompanyModel> companiesModel = null;

            if (searchstring == null && dbContext.Company.Count() > 0)
            {
                companiesModel = dbContext.Company.Take(10).ToList();
            }
            else
                companiesModel = dbContext.Company.Where(x => x.companyname.Contains(searchstring)).ToList();


            return View(companiesModel);
        }


        [HttpPost]
        public ActionResult AddCompanyReview(CompanyViewModel companyModel, HttpPostedFileBase CompanyImage)
        {

            string strPath = Server.MapPath("~/Images/");
            var client = new RestClient("https://company.clearbit.com/v1/companies/domain/"+ companyModel.CompanyName + ".com");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "a63ec061-84d4-aead-9f69-645c25d446f1");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Basic c2tfODU1ZDg1NWM4YzE4YWY5MzY5ZDZmNThlMTMwMGFjNDI6");
            IRestResponse response = client.Execute(request);
            System.Diagnostics.Debug.WriteLine("##################################");
            System.Diagnostics.Debug.WriteLine(response.Content);
            System.Diagnostics.Debug.WriteLine("##################################");
            //Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            //System.Diagnostics.Debug.WriteLine(values);
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
            System.Diagnostics.Debug.WriteLine(values.Count);
            System.Diagnostics.Debug.WriteLine(values["description"]);

            String api_description = values["description"]+ @"<br />"+
                                     "Founded in: " +values["foundedYear"]+ @"<br />" +
                                     "Headquarters: "+values["location"]+ @"<br />" +
                                     "Contact: "+values["phone"];

            try
            {
                //Get the Database Context
                ExploreDbContext dbContext = new ExploreDbContext();

                if (companyModel.CompanyImage == null)
                {
                    companyModel.CompanyImage = "untitledCompany.jpg";
                }
                else
                {
                    companyModel.CompanyImage = CompanyImage.FileName;
                    string path = System.IO.Path.Combine(strPath, companyModel.CompanyImage);
                    CompanyImage.SaveAs(path);
                    System.Diagnostics.Debug.WriteLine("Saved");
                }

                // Create Company
                CompanyModel newCompany = new CompanyModel()
                {
                    companyname = companyModel.CompanyName,
                    //location = companyModel.Lat + "," + companyModel.Long,
                    description = api_description,
                    overallrating = companyModel.rating,
                    id = Guid.NewGuid().ToString(),
                    companyimage = companyModel.CompanyImage,
                    address = companyModel.city

                    
                    
            };

                newCompany = dbContext.Company.Add(newCompany);




                // Create Job Position
                PositionModel newPosition = new PositionModel()
                {
                    id = Guid.NewGuid().ToString(),
                    companyid = newCompany.id,
                    overallrating = companyModel.rating,
                    positionname = companyModel.PositionName
                };

                newPosition = dbContext.AddPositionModel(newPosition);

                //Create Job Review
                ReviewModel newReview = new ReviewModel()
                {
                    id = Guid.NewGuid().ToString(),
                    createddate = DateTime.Now,
                    dislikes = 0,
                    likes = 0,
                    reviewmessage = companyModel.review,
                    overallrating = companyModel.rating,
                    UserId = User.Identity.GetUserId(),
                    PositionId = newPosition.id,
                    totalreview = 1
                };

                newReview = dbContext.AddReviewModel(newReview);

                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                //Suppress Exception           
            }


            return RedirectToActionPermanent("Index");
        }
    }
}