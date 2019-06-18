using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //Vehicle configuration
            builder.Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(v => v.FuelTankCapacity)
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(v => v.CostPerDay)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(v => v.Rented)
                .HasDefaultValue(false);
			builder.Property(v => v.Automatic)
				.HasDefaultValue(false);
            //Vehicle relations
            builder.HasOne(v => v.Brand)
                .WithMany(b => b.Vehicles)
                .HasForeignKey(v => v.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(v => v.VehicleType)
                .WithMany(b => b.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(v => v.Rents)
				.WithOne(re => re.Vehicle)
				.HasForeignKey(re => re.VehicleId)
				.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
