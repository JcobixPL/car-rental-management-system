using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Abstractions.Repositories
{
    public interface IVehicleCategoryRepository
    {
        Task AddAsync(VehicleCategory vehicleCategory, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<VehicleCategory>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<VehicleCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<bool> ExistsByCodeExceptIdAsync(string code, Guid excludedVehicleCategoryId, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
