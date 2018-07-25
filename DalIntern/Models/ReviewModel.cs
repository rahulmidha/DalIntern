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
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DalIntern.Models
{
    [Bind(Exclude = "Owner")]
    public class ReviewModel
    {
        public string id { get; set; }
        public string reviewmessage { get; set; }

        public int likes { get; set; }

        public int dislikes { get; set; }

        public string description { get; set; }

        public int overallrating { get; set; }

        public int totalreview { get; set; }

        public DateTime createddate { get; set; }

        public string PositionId { get; set; }

        [ForeignKey("PositionId")]
        public PositionModel Position { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [NotMapped]
        public ApplicationUser Owner { get; set; }
    }

}