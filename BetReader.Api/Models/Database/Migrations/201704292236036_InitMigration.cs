using System.Data.Entity.Migrations;

namespace BetReader.Api.Models.Database.Migrations
{
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        AuthorsYield = c.Double(nullable: false),
                        AuthorsPicksCount = c.Int(nullable: false),
                        CouponUrl = c.String(),
                        Description = c.String(),
                        Odds = c.Double(nullable: false),
                        AddedTime = c.DateTime(nullable: false),
                        IsResolved = c.Boolean(nullable: false),
                        IsWon = c.Boolean(nullable: false),
                        IsPlayed = c.Boolean(nullable: false),
                        IsDismissed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Picks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Event = c.String(),
                        KickOff = c.DateTime(nullable: false),
                        SportType = c.String(),
                        Selection = c.String(),
                        Odds = c.Double(nullable: false),
                        Coupon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coupons", t => t.Coupon_Id)
                .Index(t => t.Coupon_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picks", "Coupon_Id", "dbo.Coupons");
            DropIndex("dbo.Picks", new[] { "Coupon_Id" });
            DropTable("dbo.Picks");
            DropTable("dbo.Coupons");
        }
    }
}
