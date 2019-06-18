using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
	public class StatusConfiguration : IEntityTypeConfiguration<RentStatus>
	{
		public void Configure(EntityTypeBuilder<RentStatus> builder)
		{
			//Base entity configuration
			builder.Property(b => b.CreatedAt)
				.HasDefaultValueSql("GETDATE()");
			builder.Property(b => b.IsDeleted)
				.HasDefaultValueSql("0");
			//Rent status configuration
			builder.Property(s => s.Name)
				.IsRequired()
				.HasMaxLength(20);
			//Relations
			builder.HasMany(s => s.Rents)
				.WithOne(r => r.RentStatus)
				.HasForeignKey(s => s.StatusId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
