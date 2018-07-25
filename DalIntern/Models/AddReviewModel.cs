///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Rahul Midha                Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Rahul Midha                   25-July-2018       Class Created
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.Models
{
    public class AddReviewViewModel
    {
        public string id { get; set; }

        public string CompanyName { get; set; }

        public string PositionName { get; set; }

        public int rating { get; set; }

        public string review { get; set; }
    }
}