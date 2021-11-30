using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP586.Models
{
    public partial class COMP586VehiclesDBContext : DbContext
    {
        public COMP586VehiclesDBContext(DbContextOptions options) : base(options) {}

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<VehicleInfo> VehicleInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.OwnerId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.LicenseNum).IsUnicode(false);

                entity.Property(e => e.StateResidence).IsFixedLength(true);
            });

            modelBuilder.Entity<VehicleInfo>(entity =>
            {
                entity.Property(e => e.VehicleId).ValueGeneratedNever();

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.Make).IsUnicode(false);

                entity.Property(e => e.Model).IsUnicode(false);

                entity.Property(e => e.Vin).IsUnicode(false);

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
