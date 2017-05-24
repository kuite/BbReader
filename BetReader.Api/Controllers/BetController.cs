using System;
using System.Collections.Generic;
using System.Web.Http;
using BetReader.Api.Models.Services;
using BetReader.Model.Entities;

namespace BetReader.Api.Controllers
{
    public class BetController : ApiController
    {
        private readonly CouponService couponService;

        public BetController(CouponService couponService)
        {
            this.couponService = couponService;
        }

        public IHttpActionResult GetCouponsInPlay()
        {
            IEnumerable<Coupon> coupons = couponService.GetCouponsInPlay();

            if (coupons == null)
            {
                return NotFound();
            }

            return Ok(coupons);
        }

        public IHttpActionResult GetCouponsToPlay()
        {
            IEnumerable<Coupon> coupons = couponService.GetCouponsToPlay();

            if (coupons == null)
            {
                return NotFound();
            }
            return Ok(coupons);
        }

        public IHttpActionResult GetResolvedCoupons()
        {
            IEnumerable<Coupon> coupons = couponService.GetResolvedCoupons();

            if (coupons == null)
            {
                return NotFound();
            }
            return Ok(coupons);
        }

        [HttpPost]
        public IHttpActionResult SetCouponsInProgress(List<int> ids)
        {
            try
            {
                couponService.SetCouponsInProgress(ids);
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
            return Ok(true);
        }

        [HttpPost]
        public IHttpActionResult DismissCoupons(List<int> ids)
        {
            bool success = couponService.DismissCoupons(ids);

            if (success)
            {
                return Ok();
            }

            return InternalServerError();
        }

        [HttpPost]
        public IHttpActionResult UpdateCoupons(List<Coupon> coupons)
        {
            bool success = couponService.UpdateBulk(coupons);

            if (success)
            {
                return Ok();
            }

            return InternalServerError();
        }

        [HttpPost]
        public IHttpActionResult AddCouponsToPlay(List<Coupon> coupons)
        {
            bool success = couponService.AddBulk(coupons);

            if (success)
            {
                return Ok();
            }

            return InternalServerError();
        }
    }
}
