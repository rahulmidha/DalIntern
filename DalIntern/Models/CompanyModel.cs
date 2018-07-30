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
    public class CompanyModel
    {
        public string id { get; set; }
        public string companyname { get; set; }
        public string description { get; set; }

        public string companyimage { get; set; }

        public int overallrating { get; set; }

        public string address { get; set; }

        public string location { get; set; }

        public string logourl { get; set; }

        public string website { get; set; }

        public ICollection<PositionModel> Positions { get; set; }

    }
}