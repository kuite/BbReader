using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BetReader.Model.Entities
{
    public class Pick
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Coupon Coupon { get; set; }
        public string Event { get; set; }
        public DateTime KickOff { get; set; }
        public string SportType { get; set; }
        public string Selection { get; set; }
        public double Odds { get; set; }
    }
}
