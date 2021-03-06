﻿///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Rahul Midha       Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Rahul Midha                   25-July-2018       Class Created
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DalIntern.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexFirst()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
