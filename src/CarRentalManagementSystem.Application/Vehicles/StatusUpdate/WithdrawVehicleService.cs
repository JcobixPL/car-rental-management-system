using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.StatusUpdate
{
    public sealed class WithdrawVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public WithdrawVehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task WithdrawAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

            if (vehicle is null)
                throw new NotFoundException("Vehicle was not found.");

            if (vehicle.Status == VehicleStatus.Rented)
                throw new ConflictException("A rented car cannot be withdrawn.");

            vehicle.Withdraw();

            await _vehicleRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
