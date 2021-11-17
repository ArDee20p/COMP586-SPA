using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP586.Models
{
    public partial class COMP586VehiclesDBContext : DbContext
    {
        public COMP586VehiclesDBContext()
        {
        }

        public COMP586VehiclesDBContext(DbContextOptions<COMP586VehiclesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<VehicleInfo> VehicleInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WESTON\\SQLEXPRESS;Database=COMP586-VehiclesDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.OwnerId)
                    .ValueGeneratedNever()
                    .HasColumnName("ownerID");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LicenseNum)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.StateResidence)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("stateResidence")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VehicleInfo>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("VehicleInfo");

                entity.Property(e => e.VehicleId)
                    .ValueGeneratedNever()
                    .HasColumnName("vehicleID");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("make");

                entity.Property(e => e.Mileage).HasColumnName("mileage");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.ModelYear).HasColumnName("modelYear");

                entity.Property(e => e.OwnerId).HasColumnName("ownerID");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.VehicleInfos)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_VehicleInfo_Owner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
