using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.StatusUpdate
{
    public sealed class MarkVehicleAvailableService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public MarkVehicleAvailableService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task MarkAsAvailableAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

            if (vehicle is null)
                throw new NotFoundException("Vehicle was not found.");

            if (vehicle.Status == VehicleStatus.Withdrawn)
                throw new ConflictException("A withdrawn vehicle cannot be marked as available.");

            vehicle.MarkAsAvailable();

            await _vehicleRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
