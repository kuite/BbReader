using System.Collections.Generic;
using BetReader.Domain.Entities;

namespace BetReader.DataAccess.Database.Repositores
{
    public interface ICouponRepository : IRepository<Coupon>
    {
        void CreateBulk(IEnumerable<Coupon> coupons);
        IEnumerable<Coupon> GetCouponsInPlay();
        void UpdateCoupons(IEnumerable<Coupon> resolvedCoupons);
    }
}