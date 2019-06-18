using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
	public class RentExtraAddonConfiguration : IEntityTypeConfiguration<RentExtraAddon>
	{
		public void Configure(EntityTypeBuilder<RentExtraAddon> builder)
		{
			builder.Property(b => b.IsDeleted)
				.HasDefaultValueSql("0");
			builder.HasKey(re => new { re.RentId, re.ExtraAddonId });
			builder.Property(re => re.Price)
				.IsRequired();
		}
	}
}
