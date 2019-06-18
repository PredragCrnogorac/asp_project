using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
    public class ExtraAddonConfiguration : IEntityTypeConfiguration<ExtraAddon>
    {
        public void Configure(EntityTypeBuilder<ExtraAddon> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //Extra add-on configuration
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(e => e.Price)
                .IsRequired()
                .HasMaxLength(10);
			//Extra add-on relations
			builder.HasMany(e => e.RentExtraAddons)
				.WithOne(re => re.ExtraAddon)
				.HasForeignKey(re => re.ExtraAddonId)
				.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
