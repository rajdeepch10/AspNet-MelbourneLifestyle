namespace FinalVersion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Housing")]
    public partial class Housing
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public double Distance { get; set; }

        public int SchoolNo { get; set; }

        public int CrimeNo { get; set; }

        public int Buy_Price { get; set; }

        public int HospitalNo { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int Rent2br { get; set; }

        public int Rent3br { get; set; }

        public int Rent4br { get; set; }

        public int RentAverageAll { get; set; }

        public int Supermarket_No { get; set; }

        public int BusStop_No { get; set; }

        public int Tram_No { get; set; }

        public int Train_No { get; set; }

        public int Transport_No { get; set; }

        public int Park_No { get; set; }

        public int NormDistance { get; set; }

        public int NormCrime { get; set; }

        public int NormHospital { get; set; }

        public int NormSchool { get; set; }

        public int NormSupermarket { get; set; }

        public int NormStation { get; set; }

        public int NormPark { get; set; }

        public int NormRent2br { get; set; }

        public int NormRent3br { get; set; }

        public int NormRent4br { get; set; }

        [Required]
        [StringLength(600)]
        public string Url { get; set; }

        [Required]
        [StringLength(100)]
        public string ChinesePopulation { get; set; }

        public int ChineseCommunities { get; set; }

        public int ChineseClinics { get; set; }
    }

    public partial class Housing_Results
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public int CrimeNo { get; set; }

        public int Rent { get; set; }

        public double Distance { get; set; }

        public int SchoolNo { get; set; }

        public int HospitalNo { get; set; }

        public int SupermarketNo { get; set; }

        public int BusStop_No { get; set; }

        public int Tram_No { get; set; }

        public int Train_No { get; set; }

        public int ParkNo { get; set; }

        [StringLength(100)]
        public string ChinesePopulation { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        public decimal Longitude { get; set; }
    }

    public partial class Updated_Results
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public int SchoolNo { get; set; }

    }

    public partial class Suburb_Map
    {
        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        public decimal Longitude { get; set; }
    }

    public partial class MyViewModel
    {
        public List<Housing> Housing_Details { get; set; }
        public List<SchoolDetail> School_Details { get; set; }
        public List<HospitalDetail> Hospital_Details { get; set; }
        public List<ChineseClinic> Clinic_Details { get; set; }
        public List<ChineseCommunity> Community_Details { get; set; }
        public List<Park> Park_Details { get; set; }
        public List<BusStation> Bus_Details { get; set; }
        public List<TrainStation> Train_Details { get; set; }
        public List<TramStation> Tram_Details { get; set; }
        public List<Supermarket> Supermarket_Details { get; set; }
    }
}
