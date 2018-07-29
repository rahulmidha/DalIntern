namespace DalIntern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyModels",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        companyname = c.String(),
                        description = c.String(),
                        overallrating = c.Int(nullable: false),
                        address = c.String(),
                        location = c.String(),
                        logourl = c.String(),
                        website = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PositionModels",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        positionname = c.String(),
                        description = c.String(),
                        overallrating = c.Int(nullable: false),
                        totalrevies = c.Int(nullable: false),
                        companyid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CompanyModels", t => t.companyid)
                .Index(t => t.companyid);
            
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        reviewmessage = c.String(),
                        likes = c.Int(nullable: false),
                        dislikes = c.Int(nullable: false),
                        description = c.String(),
                        overallrating = c.Int(nullable: false),
                        totalreview = c.Int(nullable: false),
                        createddate = c.DateTime(nullable: false),
                        PositionId = c.String(maxLength: 128),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PositionModels", t => t.PositionId)
                .Index(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewModels", "PositionId", "dbo.PositionModels");
            DropForeignKey("dbo.PositionModels", "companyid", "dbo.CompanyModels");
            DropIndex("dbo.ReviewModels", new[] { "PositionId" });
            DropIndex("dbo.PositionModels", new[] { "companyid" });
            DropTable("dbo.ReviewModels");
            DropTable("dbo.PositionModels");
            DropTable("dbo.CompanyModels");
        }
    }
}
