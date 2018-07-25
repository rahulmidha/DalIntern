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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.Models
{
    public class PositionModel
    {
        public string id { get; set; }

        public string positionname { get; set; }

        public string description { get; set; }

        public int overallrating { get; set; }

        public int totalrevies { get; set; }

        public string companyid { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("companyid")]
        public CompanyModel company { get; set; }

        public ICollection<ReviewModel> Reviews { get; set; }
    }
}