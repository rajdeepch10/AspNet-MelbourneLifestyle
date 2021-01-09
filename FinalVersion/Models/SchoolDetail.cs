namespace FinalVersion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SchoolDetail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(500)]
        public string Phone_number { get; set; }

        [Required]
        [StringLength(250)]
        public string School_Name { get; set; }

        [Required]
        [StringLength(250)]
        public string School_Type { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(500)]
        public string URL { get; set; }

        public double Rating { get; set; }
    }
}
