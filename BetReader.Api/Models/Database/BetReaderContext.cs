using System.Data.Entity;
using BetReader.Model.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BetReader.Api.Models.Database
{
    public class BetReaderContext : IdentityDbContext<IdentityUser>
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
