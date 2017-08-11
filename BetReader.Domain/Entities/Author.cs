using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BetReader.Domain.Entities.Enums;

namespace BetReader.Domain.Entities
{
    public class Author : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Source HomeSite { get; set; }
        public string Name { get; set; }
        public double? Yield { get; set; }
        public int? PicksCount { get; set; }
        public int? Profit { get; set; }
    }
}
