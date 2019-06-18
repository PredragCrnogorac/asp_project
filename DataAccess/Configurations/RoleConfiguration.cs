using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccessModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //Role configuration
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(20);
            //Role relations
            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
