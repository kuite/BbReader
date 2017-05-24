using System.Data.Entity;
using BetReader.Model.Entities;
using BetReader.Web.Model.Identity;

namespace BetReader.Api.Models
{
    public class BetReaderContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Pick> Picks { get; set; }

        public BetReaderContext() 
            : base("name=BetReaderDataBase")
        {

        }

        public static BetReaderContext Create()
        {
            return new BetReaderContext();
        }
    }
}
