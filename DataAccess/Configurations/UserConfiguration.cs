using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccessModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //user configuration
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(20);
            builder.Property(u => u.Username)
               .IsRequired()
               .HasMaxLength(20);
			builder.Property(u => u.Password)
			   .IsRequired()
			   .HasMaxLength(50);
			builder.HasIndex(u => u.Username)
                .IsUnique();
            builder.Property(u => u.RoleId)
                .HasDefaultValueSql("8");
            //User relations
            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(u => u.Rents)
				.WithOne(r => r.User)
				.HasForeignKey(r => r.UserId)
				.OnDelete(DeleteBehavior.Restrict);

        }
    }
}
