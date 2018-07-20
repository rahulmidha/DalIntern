using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Mvc;

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
    }

    public class CompanyModel
    {
        public string id { get; set; }
        public string companyname { get; set; }
        public string description { get; set; }

        public int overallrating { get; set; }

        public string address { get; set; }

        public string location { get; set; }

        public string logourl { get; set; }

        public string website { get; set; }

        public ICollection<PositionModel> Positions { get; set; }

    }

    public class CompanyViewModel
    {
        public string id { get; set; }

        public string CompanyName { get; set; }

        public string PositionName { get; set; }

        public int rating { get; set; }

        public string review { get; set; }

        public string Lat { get; set; }
        public string Long { get; set; }
    }

    public class PositionModel
    {
        public string id { get; set; }

        public string positionname { get; set; }

        public string description { get; set; }

        public int overallrating { get; set; }

        public int totalrevies { get; set; }

        public string companyid { get; set; }

        [ForeignKey("companyid")]
        public CompanyModel company { get; set; }

        public ICollection<ReviewModel> Reviews { get; set; }
    }


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



    public class AddReviewViewModel
    {
        public string id { get; set; }

        public string CompanyName { get; set; }

        public string PositionName { get; set; }

        public int rating { get; set; }

        public string review { get; set; }
    }

}