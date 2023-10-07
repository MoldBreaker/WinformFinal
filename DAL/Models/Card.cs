namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Card")]
    public partial class Card
    {
        [Key]
        [StringLength(20)]
        public string CardNumber { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string Rank { get; set; }

        public int? Point { get; set; }

        public virtual User User { get; set; }
    }
}
