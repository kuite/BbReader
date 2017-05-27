using System.Data.Entity.Migrations;

namespace BetReader.Api.Models.Database.Migrations
{
    public partial class StakeAndIsLiveProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "AuthorsStake", c => c.Int(nullable: false));
            AddColumn("dbo.Coupons", "IsLive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "IsLive");
            DropColumn("dbo.Coupons", "AuthorsStake");
        }
    }
}
