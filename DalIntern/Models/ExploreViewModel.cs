///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Anudeep Buchhanagari         Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Anudeep Buchhanagari          25-July-2018       Class Created
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Mvc;
using DalIntern.RatingAggregator;

namespace DalIntern.Models
{
    public class ExploreDbContext : DbContext
    {
        public ExploreDbContext()
            : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<CompanyModel> Company { get; set; }

        public DbSet<PositionModel> Position { get; set; }

        public DbSet<ReviewModel> Review { get; set; }

        public PositionModel AddPositionModel(PositionModel model)
        {
            PositionModel newModel = Position.Add(model);
            IRatingAggregator ratingAggregator = new RatingAggregator.RatingAggregator(this);

            ratingAggregator.OnInsertOfPositionRecord(newModel);

            return newModel;                      
        }


        public ReviewModel AddReviewModel(ReviewModel model)
        {
            ReviewModel newModel = Review.Add(model);
            IRatingAggregator ratingAggregator = new RatingAggregator.RatingAggregator(this);

            ratingAggregator.OnInsertOfReviewRecord(newModel);

            return newModel;
        }

    }

}