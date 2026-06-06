using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.Create
{
    public sealed class CreateVehicleCategoryService
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public CreateVehicleCategoryService(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task<VehicleCategoryResponse> CreateAsync(
            CreateVehicleCategoryRequest request,
            CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);

            var categoryExists = await _vehicleCategoryRepository.ExistsByCodeAsync(
                request.Code,
                cancellationToken);

            if (categoryExists)
            {
                throw new ConflictException("Vehicle category with given Code already exists.");
            }

            var vehicleCategory = new VehicleCategory(
                request.Code,
                request.Name,
                request.Description,
                request.TransmissionType);

            await _vehicleCategoryRepository.AddAsync(vehicleCategory, cancellationToken);
            await _vehicleCategoryRepository.SaveChangesAsync(cancellationToken);

            return new VehicleCategoryResponse(
                vehicleCategory.Id,
                vehicleCategory.Code,
                vehicleCategory.Name,
                vehicleCategory.TransmissionType,
                vehicleCategory.Description,
                vehicleCategory.IsActive);
        }

        private static void ValidateRequest(CreateVehicleCategoryRequest request)
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
