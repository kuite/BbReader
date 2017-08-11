namespace Betreader.DataAccess.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSourceInCoupon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Coupons", "Source");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coupons", "Source", c => c.Int(nullable: false));
        }
    }
}
