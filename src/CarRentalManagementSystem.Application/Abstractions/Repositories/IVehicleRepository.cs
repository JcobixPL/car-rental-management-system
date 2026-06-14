using CarRentalManagementSystem.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Abstractions.Repositories
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsByVinAsync(string vin, CancellationToken cancellation = default);
        Task<bool> ExistsByRegistrationNumberAsync(string registrationNumber, CancellationToken cancellationToken = default);
        Task<bool> ExistsByVinExceptIdAsync(string vin, Guid excludedVehicleId, CancellationToken cancellationToken = default);
        Task<bool> ExistsByRegistrationNumberExceptIdAsync(string registrationNumber, Guid excludedVehicleId, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
