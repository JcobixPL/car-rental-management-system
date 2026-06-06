using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Infrastructure.Data.Configurations
{
    public sealed class VehicleCategoryConfiguration : IEntityTypeConfiguration<VehicleCategory>
    {
        public void Configure(EntityTypeBuilder<VehicleCategory> builder)
        {
            builder.ToTable("vehicle_categories");

            builder.HasKey(vc => vc.Id);

            builder.Property(vc => vc.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(vc => vc.Code)
                .HasColumnName("code")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(vc => vc.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(vc => vc.TransmissionType)
                .HasColumnName("transmission_type")
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(vc => vc.Description)
               .HasColumnName("description")
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(vc => vc.IsActive)
               .HasColumnName("is_active")
               .IsRequired();

            builder.HasIndex(vc => vc.Code)
                .IsUnique();
        }
    }
}
