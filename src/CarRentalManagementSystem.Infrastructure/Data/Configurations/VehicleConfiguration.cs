using CarRentalManagementSystem.Domain.Entities.Branches;
using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Infrastructure.Data.Configurations
{
    public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("vehicles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(x => x.Vin)
                .HasColumnName("vin")
                .IsRequired()
                .HasMaxLength(17);

            builder.Property(x => x.RegistrationNumber)
                .HasColumnName("registration_number")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Brand)
                .HasColumnName("brand")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Model)
                .HasColumnName("model")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ProductionYear)
                .HasColumnName("production_year")
                .IsRequired();

            builder.Property(x => x.VehicleCategoryId)
                .HasColumnName("vehicle_category_id")
                .IsRequired();

            builder.Property(x => x.CurrentBranchId)
                .HasColumnName("current_branch_id")
                .IsRequired();

            builder.Property(x => x.CurrentMileage)
                .HasColumnName("current_mileage")
                .IsRequired();

            builder.Property(x => x.FuelType)
                .HasColumnName("fuel_type")
                .HasConversion<string>() 
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.TransmissionType)
                .HasColumnName("transmission_type")
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.NextTechnicalInspectionDate)
                .HasColumnName("next_technical_inspection_date")
                .IsRequired();

            builder.Property(x => x.NextServiceMileage)
                .HasColumnName("next_service_mileage")
                .IsRequired();

            builder.Property(x => x.NextServiceDate)
                .HasColumnName("next_service_date")
                .IsRequired();

            builder.HasIndex(x => x.Vin)
                .IsUnique();

            builder.HasIndex(x => x.RegistrationNumber)
                .IsUnique();

            builder.HasOne<Branch>()
                .WithMany()
                .HasForeignKey(x => x.CurrentBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<VehicleCategory>()
                .WithMany()
                .HasForeignKey(x => x.VehicleCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
