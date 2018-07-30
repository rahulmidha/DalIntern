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

namespace DalIntern.Models
{
    public class CompanyViewModel
    {
        public string id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyImage { get; set; }

        public string PositionName { get; set; }

        public string city { get; set; }

        public int rating { get; set; }

        public string review { get; set; }

        public string Lat { get; set; }
        public string Long { get; set; }
    }
}