using CarRentalManagementSystem.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.Get
{
    public sealed class GetVehicleByIdService
    {
        private readonly IVehicleRepository _vehicleRepository;
    
        public GetVehicleByIdService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleResponse?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

            if (vehicle is null)
                return null;

            return new VehicleResponse(
                vehicle.Id,
                vehicle.Vin,
                vehicle.RegistrationNumber,
                vehicle.Brand,
                vehicle.Model,
                vehicle.ProductionYear,
                vehicle.VehicleCategoryId,
                vehicle.CurrentBranchId,
                vehicle.CurrentMileage,
                vehicle.FuelType,
                vehicle.TransmissionType,
                vehicle.OperationalStatus,
                vehicle.NextTechnicalInspectionDate,
                vehicle.NextServiceMileage,
                vehicle.NextServiceDate);
        }
    }
}
