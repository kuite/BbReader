using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Betreader.DataAccess.Database;
using BetReader.Domain.Entities;

namespace BetReader.DataAccess.Database.Repositores
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

        public void CreateBulk(IEnumerable<Coupon> coupons)
        {
            List<Author> existingAuthors = context.Authors.ToList();
            List<Coupon> existingCoupons = context.Coupons.ToList();
            List<Author> authors = new List<Author>();
            foreach (Coupon c in coupons)
            {
                if (existingCoupons.Contains(c))
                {
                    continue;
                }
                Author atr = existingAuthors.FirstOrDefault(a => a.Name == c.Author.Name) ??
                             authors.FirstOrDefault(a => a.Name == c.Author.Name);
                if (atr == null)
                {
                    authors.Add(c.Author);
                }
                else
                {
                    atr.PicksCount = c.Author.PicksCount;
                    atr.Yield = c.Author.Yield;
                    c.Author = atr;
                }
                context.Coupons.Add(c);
            }
            context.SaveChanges();
        }

        public IEnumerable<Coupon> GetCouponsInPlay()
        {
            throw new NotImplementedException();
        }

        public void UpdateCoupons(IEnumerable<Coupon> resolvedCoupons)
        {
            throw new NotImplementedException();
        }
    }
}
