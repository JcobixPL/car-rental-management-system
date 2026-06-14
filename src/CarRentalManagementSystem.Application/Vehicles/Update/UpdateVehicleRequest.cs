using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.Update
{
    public sealed record UpdateVehicleRequest(
        string Vin,
        string RegistrationNumber,
        string Brand,
        string Model,
        int ProductionYear,
        Guid VehicleCategoryId,
        Guid CurrentBranchId,
        FuelType FuelType,
        TransmissionType TransmissionType,
        DateOnly NextTechnicalInspectionDate,
        int NextServiceMileage,
        DateOnly NextServiceDate);
}
