using DalIntern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DalIntern.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (ExploreDbContext dbContext = new ExploreDbContext())
            {
                IEnumerable<CompanyModel> viewModel = dbContext.Company.ToList();
                return View(viewModel);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyModel model)
        {
            using (ExploreDbContext dbContext = new ExploreDbContext())
            {
                dbContext.Company.Add(model);
                dbContext.SaveChanges();
            }
            return View("Index");
        }


        public ActionResult Edit(string id)
        {
            using (ExploreDbContext dbContext = new ExploreDbContext())
            {
             var model =    dbContext.Company.Where(x => x.id == id).FirstOrDefault();
                return View(model);
            }

        }

        public ActionResult Delete(string id)
        {
            using (ExploreDbContext dbContext = new ExploreDbContext())
            {
                var model = dbContext.Company.Where(x => x.id == id).FirstOrDefault();
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult Edit(CompanyModel model)
        {
            using (ExploreDbContext dbContext = new ExploreDbContext())
            {
                CompanyModel editModel = dbContext.Company.Where(x => x.id == model.id).FirstOrDefault();
                if(editModel!=null)
                {
                    editModel.description = model.description;
                    editModel.companyname = model.companyname;
                    editModel.address = model.address;
                    editModel.location = model.location;
                    editModel.logourl = model.logourl;
                    editModel.website = model.website;
                    dbContext.SaveChanges();
                }
               
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Delete(CompanyModel model)
        {
            using (ExploreDbContext dbContext = new ExploreDbContext())
            {
               
                if (model != null)
                {
                    System.Diagnostics.Debug.WriteLine(model);
                    dbContext.Company.Remove(model);
                }

            }
            return RedirectToAction("Index");
        }


    }
}