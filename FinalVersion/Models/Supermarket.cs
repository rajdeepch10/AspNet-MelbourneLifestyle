namespace FinalVersion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supermarket")]
    public partial class Supermarket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
