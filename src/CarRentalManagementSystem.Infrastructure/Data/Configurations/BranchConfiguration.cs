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
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(b => b.City)
                .HasColumnName("city")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Address)
                .HasColumnName("address")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.PhoneNumber)
                .HasColumnName("phone_number")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(b => b.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.IsActive)
                .HasColumnName("is_active")
                .IsRequired();
        }
    }
}
