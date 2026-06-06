using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.Update
{
    public sealed class UpdateVehicleCategoryService
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public UpdateVehicleCategoryService(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task UpdateAsync(
            Guid id,
            UpdateVehicleCategoryRequest request,
            CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);

            var vehicleCategory = await _vehicleCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (vehicleCategory is null)
                throw new NotFoundException("Vehicle category was not found.");

            var categoryExists = await _vehicleCategoryRepository.ExistsByCodeExceptIdAsync(
                request.Code,
                id,
                cancellationToken);

            if (categoryExists)
                throw new ConflictException("A vehicle category with the same code already exists.");

            vehicleCategory.UpdateDetails(
                request.Code,
                request.Name,
                request.Description,
                request.TransmissionType);

            await _vehicleCategoryRepository.SaveChangesAsync(cancellationToken);
        }

        private static void ValidateRequest(UpdateVehicleCategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Code))
            {
                throw new ValidationException("Code is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                throw new ValidationException("Description is required.");
            }
        }
    }
}
