using System.Data.Entity;
using BetReader.Model.Entities;
using BetReader.Model.Entities.Identity;
using BetReader.Web.Model.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BetReader.Web.Model
{
    public class BetReaderContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Pick> Picks { get; set; }

        public BetReaderContext() 
            : base("name=BetReaderDataBase")
        {
            System.Data.Entity.Database.SetInitializer<BetReaderContext>(null);
            Database.Initialize(true);
        }

        public static BetReaderContext Create()
        {
            return new BetReaderContext();
        }
    }
}
