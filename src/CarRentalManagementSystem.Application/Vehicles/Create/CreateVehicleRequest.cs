using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.Create
{
    public sealed record CreateVehicleRequest(
        string Vin,
        string RegistrationNumber,
        string Brand,
        string Model,
        int ProductionYear,
        Guid VehicleCategoryId,
        Guid CurrentBranchId,
        int CurrentMileage,
        FuelType FuelType,
        TransmissionType TransmissionType,
        DateOnly NextTechnicalInspectionDate,
        int NextServiceMileage,
        DateOnly NextServiceDate);
}
