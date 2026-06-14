using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.UpdateMileage
{
    public sealed class UpdateVehicleMileageService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleMileageService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task UpdateAsync(
            Guid id,
            UpdateVehicleMileageRequest request,
            CancellationToken cancellationToken = default)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

            if (vehicle is null)
                throw new NotFoundException("Vehicle was not found");

            if (request.Mileage < vehicle.CurrentMileage)
                throw new ValidationException("New mileage cannot be lower than the current mileage.");

            vehicle.UpdateMileage(request.Mileage);

            await _vehicleRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
