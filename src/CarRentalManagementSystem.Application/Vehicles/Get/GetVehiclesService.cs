using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.Get
{
    public sealed class GetVehiclesService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IReadOnlyList<VehicleResponse>> GetAsync(
            CancellationToken cancellationToken = default)
        {
            var vehicles = await _vehicleRepository.GetAllAsync(cancellationToken);

            return vehicles
                .Select(vehicle => new VehicleResponse(
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
                    vehicle.Status,
                    vehicle.NextTechnicalInspectionDate,
                    vehicle.NextServiceMileage,
                    vehicle.NextServiceDate))
                .ToList();
        }
    }
}
