using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.StatusUpdate
{
    public sealed class ActivateVehicleCategoryService
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public ActivateVehicleCategoryService(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task ActivateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var vehicleCategory = await _vehicleCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (vehicleCategory is null)
                throw new NotFoundException("Vehicle category was not found.");

            vehicleCategory.Activate();

            await _vehicleCategoryRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
