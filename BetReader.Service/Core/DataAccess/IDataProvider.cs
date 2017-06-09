using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetReader.Model.Entities;

namespace BetReader.Service.Core.DataAccess
{
    public interface IDataProvider
    {
        List<Coupon> GetCouponsInPlay();
        void UpdateCoupons(List<Coupon> coupons);
        void AddCouponsToPlay(List<Coupon> coupons);
    }
}
