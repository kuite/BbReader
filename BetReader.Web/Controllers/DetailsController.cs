using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetReader.Model.Entities;

namespace BetReader.Web.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details

        public DetailsController()
        {
            
        }

        
        [HttpPost]
        public ActionResult ShowCouponDetails(string couponDetails)
        {
            var coupon = new Coupon();
            return PartialView("~/Views/Shared/_CouponDetails.cshtml");
        }
    }
}