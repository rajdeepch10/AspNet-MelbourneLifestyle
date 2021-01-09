namespace FinalVersion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChineseClinic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(200)]
        public string ContactNumber { get; set; }

        public int? Rating { get; set; }

        [StringLength(600)]
        public string Website { get; set; }
    }
}
