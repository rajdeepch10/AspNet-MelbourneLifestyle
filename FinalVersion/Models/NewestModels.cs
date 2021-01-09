namespace FinalVersion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewestModels : DbContext
    {
        public NewestModels()
            : base("name=NewestModels")
        {
        }

        public virtual DbSet<BusStation> BusStations { get; set; }
        public virtual DbSet<ChineseClinic> ChineseClinics { get; set; }
        public virtual DbSet<ChineseCommunity> ChineseCommunities { get; set; }
        public virtual DbSet<HospitalDetail> HospitalDetails { get; set; }
        public virtual DbSet<Housing> Housings { get; set; }
        public virtual DbSet<Park> Parks { get; set; }
        public virtual DbSet<SchoolDetail> SchoolDetails { get; set; }
        public virtual DbSet<Supermarket> Supermarkets { get; set; }
        public virtual DbSet<TrainStation> TrainStations { get; set; }
        public virtual DbSet<TramStation> TramStations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusStation>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<BusStation>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BusStation>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<BusStation>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseClinic>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ChineseCommunity>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDetail>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDetail>()
                .Property(e => e.Hospital_Name)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDetail>()
                .Property(e => e.Hospital_Type)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDetail>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDetail>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<Housing>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Housing>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Housing>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Housing>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Housing>()
                .Property(e => e.ChinesePopulation)
                .IsUnicode(false);

            modelBuilder.Entity<Park>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Park>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Park>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Park>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<SchoolDetail>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolDetail>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolDetail>()
                .Property(e => e.School_Name)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolDetail>()
                .Property(e => e.School_Type)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolDetail>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolDetail>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<Supermarket>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Supermarket>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supermarket>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Supermarket>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<TrainStation>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<TrainStation>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TrainStation>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<TrainStation>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<TramStation>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<TramStation>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TramStation>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<TramStation>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);
        }
    }
}
