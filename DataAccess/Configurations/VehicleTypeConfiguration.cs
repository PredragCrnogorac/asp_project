using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //Brand configuration
            builder.Property(vt => vt.Name)
                .HasMaxLength(20);
            //Relations
            builder.HasMany(vt => vt.Vehicles)
                .WithOne(v => v.VehicleType)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
