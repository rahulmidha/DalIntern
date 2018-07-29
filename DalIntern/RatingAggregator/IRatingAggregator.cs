using DalIntern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalIntern.RatingAggregator
{
    interface IRatingAggregator
    {

        void OnInsertOfReviewRecord(ReviewModel model);

        void OnInsertOfPositionRecord(PositionModel model);

        void OnInsertOfCompanyRecord(CompanyModel model);

    }
}
