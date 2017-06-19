using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetReader.Model.Entities
{
    public class Coupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        public double AuthorsYield { get; set; }
        public int AuthorsPicksCount { get; set; }
        public int AuthorsStake { get; set; }
        public string CouponUrl { get; set; }
        public string Description { get; set; }
        public double Odds { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsResolved { get; set; }
        public bool IsWon { get; set; }
        public bool IsPlayed { get; set; }
        public bool IsDismissed { get; set; }
        public bool IsLive { get; set; }
        public virtual List<Pick> Picks { get; set; } = new List<Pick>();

        public bool Equals(Coupon coupon)
        {
            if (coupon.CouponUrl != CouponUrl)
            {
                return false;
            }

            if (coupon.AddedTime != AddedTime)
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Coupon coupon = (Coupon)obj;
            return Equals(coupon);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
