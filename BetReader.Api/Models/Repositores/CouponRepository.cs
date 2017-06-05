using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BetReader.Api.Models.Database;
using BetReader.Model.Entities;

namespace BetReader.Api.Models.Repositores
{
    public class CouponRepository : ICouponRepository
    {
        private readonly BetReaderContext context;

        public CouponRepository(BetReaderContext context)
        {
            this.context = context;
        }

        public IQueryable<Coupon> GetAll()
        {
            return context.Coupons;
        }

        public Coupon GetById(int id)
        {
            return context.Coupons.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Coupon entity)
        {
            context.Coupons.Add(entity);
        }

        public void Update(Coupon entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void BulkInsert(IEnumerable<Coupon> coupons)
        {
            foreach (Coupon c in coupons)
            {
                context.Coupons.Add(c);
            }
            context.SaveChanges();
        }
    }
}
