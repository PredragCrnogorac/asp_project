using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
	public class RentConfiguration : IEntityTypeConfiguration<Rent>
	{
		public void Configure(EntityTypeBuilder<Rent> builder)
		{
			//Base entity configuration
			builder.Property(b => b.CreatedAt)
				.HasDefaultValueSql("GETDATE()");
			builder.Property(b => b.IsDeleted)
				.HasDefaultValueSql("0");
			//Rent configuration, everything is configured in other tables
			//Relations
			builder.HasOne(r => r.User)
				.WithMany(u => u.Rents)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(r => r.Customer)
				.WithMany(c => c.Rents)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(r => r.RentStatus)
				.WithMany(s => s.Rents)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(r => r.Location)
				.WithMany(l => l.Rents)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(r => r.RentExtraAddons)
				.WithOne(re => re.Rent)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
