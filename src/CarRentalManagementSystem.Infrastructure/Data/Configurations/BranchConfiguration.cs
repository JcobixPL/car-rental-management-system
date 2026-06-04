using CarRentalManagementSystem.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Infrastructure.Data.Configurations
{
    public sealed class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("branches");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedNever();

            builder.Property(b => b.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.IsActive)
                .IsRequired();
        }
    }
}
