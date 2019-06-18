using System;
using System.Collections.Generic;
using System.Text;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			//Base entity configuration
			builder.Property(b => b.CreatedAt)
				.HasDefaultValueSql("GETDATE()");
			builder.Property(b => b.IsDeleted)
				.HasDefaultValueSql("0");
			//Customer configuration
			builder.Property(c => c.FirstName)
			   .IsRequired()
			   .HasMaxLength(20);
			builder.Property(c => c.LastName)
			   .IsRequired()
			   .HasMaxLength(20);
			builder.Property(c => c.Email)
			   .IsRequired();
			builder.Property(c => c.PhoneNumber)
				.IsRequired()
				.HasMaxLength(20);
			//Customer relations
			builder.HasMany(c => c.Rents)
				.WithOne(r => r.Customer)
				.HasForeignKey(r => r.CustomerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
