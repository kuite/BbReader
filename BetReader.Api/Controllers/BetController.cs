using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using BetReader.Api.Filters;
using BetReader.Api.Models.Services;
using BetReader.Model.Entities;

namespace BetReader.Api.Controllers
{
    [JwtAuthentication]
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
            return Ok(coupons);
        }

        public IHttpActionResult GetCouponsToPlay()
        {
            IEnumerable<Coupon> coupons = couponService.GetCouponsToPlay();
            return Ok(coupons);
        }

        public IHttpActionResult GetResolvedCoupons()
        {
            IEnumerable<Coupon> coupons = couponService.GetResolvedCoupons();
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
            try
            {
                couponService.DismissCoupons(ids);
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateCoupons(List<Coupon> coupons)
        {
            try
            {
                couponService.UpdateCoupons(coupons);
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddNewCoupons([FromBody]IEnumerable<Coupon> coupons)
        {
            try
            {
                couponService.AddCoupons(coupons);
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
            return Ok();
        }
    }
}
