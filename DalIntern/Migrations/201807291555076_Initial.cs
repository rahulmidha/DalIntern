namespace DalIntern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyModels", "companyimage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyModels", "companyimage");
        }
    }
}
