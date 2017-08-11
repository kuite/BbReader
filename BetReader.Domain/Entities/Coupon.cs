using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BetReader.Domain.Entities.Enums;

namespace BetReader.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Bookie { get; set; }
        public string CouponUrl { get; set; }
        public string Description { get; set; }
        public double Odds { get; set; }
        public int SuggestedStake { get; set; }
        public DateTime CreatedAtSource { get; set; }
        public bool IsLive { get; set; }
        public bool? Won { get; set; }
        public virtual List<Pick> Picks { get; set; } = new List<Pick>();

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

        private bool Equals(Coupon coupon)
        {
            if (coupon.CouponUrl != CouponUrl)
            {
                return false;
            }

            if (coupon.CreatedAtSource != CreatedAtSource)
            {
                return false;
            }

            return true;
        }
        //todo: extension method to filter list of cupons on Settings instance
    }
}
