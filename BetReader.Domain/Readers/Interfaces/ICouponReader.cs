using System;
using System.Collections.Generic;
using BetReader.Domain.Entities;

namespace BetReader.Domain.Readers.Interfaces
{
    public interface ICouponReader : IDisposable
    {
        IEnumerable<Coupon> GetAll(double minAuthorYield, int minAuthorPicks);
    }
}
