using System.Data.Entity;
using BetReader.Model.Entities;

namespace BetReader.Service.Core.DataAccess
{
    public class BetReaderContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Pick> Picks { get; set; }

        public BetReaderContext() 
            : base("name=BetReaderDataBase")
        {

        }
    }
}
