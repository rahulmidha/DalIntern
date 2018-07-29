using DalIntern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DalIntern.RatingAggregator
{
    public class RatingAggregator : IRatingAggregator
    {
        private ExploreDbContext _dbContext = null;
        public RatingAggregator(ExploreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void OnInsertOfCompanyRecord(CompanyModel model)
        {
            try
            {
                if (model == null)
                    return;


            }
            catch (Exception)
            {

            }
        }

        public void OnInsertOfPositionRecord(PositionModel model)
        {
            try
            {
                // Update the Companies Rating based on the Position Rating
                if (model == null)
                    return;
                IEnumerable<PositionModel> positionList = _dbContext.Position.Where(x => x.companyid == model.companyid);
                int calculatedRating = Convert.ToInt32((positionList.Average(x => x.overallrating) + model.overallrating) / 2);

                // Get the Company Record
                CompanyModel companyModel = _dbContext.Company.Where(comp => comp.id == model.companyid).FirstOrDefault();
                if (companyModel != null)
                {
                    companyModel.overallrating = calculatedRating;
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void OnInsertOfReviewRecord(ReviewModel model)
        {
            try
            {
                if (model == null)
                    return;

                IEnumerable<ReviewModel> reviewList = _dbContext.Review.Where(review => review.PositionId == model.PositionId);
                int calculatedRating = Convert.ToInt32((reviewList.Average(x => x.overallrating) + model.overallrating) / 2);

                PositionModel positionModel = _dbContext.Position.Where(pos => pos.id == model.PositionId).FirstOrDefault();
                if (positionModel != null)
                {
                    positionModel.overallrating = calculatedRating;
                    // Call on Insert of Position record
                    OnInsertOfPositionRecord(positionModel);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}