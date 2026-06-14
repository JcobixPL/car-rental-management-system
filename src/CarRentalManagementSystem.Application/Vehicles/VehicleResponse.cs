using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles
{
    public sealed record VehicleResponse(
        Guid Id,
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
        VehicleOperationalStatus OperationalStatus,
        DateOnly NextTechnicalInspectionDate,
        int NextServiceMileage,
        DateOnly NextServiceDate);
}
