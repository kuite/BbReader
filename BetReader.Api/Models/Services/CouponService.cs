﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BetReader.Api.Models.Repositores;
using BetReader.Domain.Entities;

namespace BetReader.Api.Models.Services
{
    public class CouponService
    {
        private readonly ICouponRepository couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
        }

        public IEnumerable<Coupon> GetCouponsInPlay()
        {
            //            return couponRepository.GetAll().Where(c =>
            //                c.IsPlayed &&
            //                c.IsResolved == false).ToList();
            return new List<Coupon>();
        }

        public void SetCouponsInProgress(IEnumerable<int> ids)
        {
//            foreach (var couponId in ids)
//            {
//                Coupon coupon = couponRepository.GetById(couponId);
//                coupon.IsPlayed = true;
//                couponRepository.Update(coupon);
//            }
        }

        public bool DismissCoupons(IEnumerable<int> ids)
        {
            //            foreach (var couponId in ids)
            //            {
            //                Coupon coupon = couponRepository.GetById(couponId);
            //                //coupon.IsDismissed = true;
            //                couponRepository.Update(coupon);
            //            }
            return true;
        }

        public IEnumerable<Coupon> GetCouponsToPlay()
        {
            throw new NotImplementedException();
//            return couponRepository.GetAll().Where(c =>
//                c.IsResolved == false).ToList();
        }

        public IEnumerable<Coupon> GetResolvedCoupons()
        {
            throw new NotImplementedException();
            //            return couponRepository.GetAll().Where(c =>
            //                c.IsResolved).ToList();
        }

        public bool AddCoupons(IEnumerable<Coupon> coupons)
        {
            try
            {
                foreach (var singleCoupon in coupons)
                {
                    AddAsUnique(singleCoupon);
                }
                couponRepository.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //log e
                return false;
            }

        }

        public bool UpdateCoupons(List<Coupon> coupons)
        {
            foreach (var singleCoupon in coupons)
            {
                couponRepository.Update(singleCoupon);
            }
            return true;
        }

        private void AddAsUnique(Coupon coupon)
        {
            throw new NotImplementedException();
            //            var couponsToPlay = couponRepository.GetAll().
            //                Where(c => c.IsResolved == false);
            //
            //            foreach (Coupon toPlay in couponsToPlay)
            //            {
            //                if (toPlay.Equals(coupon))
            //                {
            //                    return;
            //                }
            //            }
            //            couponRepository.Add(coupon);
        }
    }
}