using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.Get
{
    public sealed class GetVehicleCategoryByIdService
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public GetVehicleCategoryByIdService(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task<VehicleCategoryResponse?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var category = await _vehicleCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (category is null)
                throw new NotFoundException($"Vehicle category with id {id} was not found.");

            return new VehicleCategoryResponse(
                category.Id,
                category.Name,
                category.Code,
                category.TransmissionType,
                category.Description,
                category.IsActive);
        }
    }
}
