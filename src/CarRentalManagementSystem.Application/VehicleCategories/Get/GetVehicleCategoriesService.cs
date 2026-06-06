using CarRentalManagementSystem.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.Get
{
    public sealed class GetVehicleCategoriesService
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public GetVehicleCategoriesService(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task<IReadOnlyList<VehicleCategoryResponse>> GetAllAsync(
            CancellationToken cancellationToken)
        {
            var categories = await _vehicleCategoryRepository.GetAllAsync(cancellationToken);

            return categories
                .Select(c => new VehicleCategoryResponse(
                    c.Id,
                    c.Code,
                    c.Name,
                    c.TransmissionType,
                    c.Description,
                    c.IsActive))
                .ToList();
        }
    }
}
