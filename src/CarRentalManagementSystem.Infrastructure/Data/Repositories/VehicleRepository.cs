using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Infrastructure.Data.Repositories
{
    public sealed class VehicleRepository : IVehicleRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public VehicleRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
        {
            await _dbContext.Vehicles.AddAsync(vehicle, cancellationToken);
        }

        public async Task<IReadOnlyList<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Vehicles
                .AsNoTracking()
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model)
                .ThenBy(v => v.RegistrationNumber)
                .ToListAsync(cancellationToken);
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Vehicles
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

        }

        public async Task<bool> ExistsByVinAsync(string vin, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Vehicles
                .AnyAsync(v => v.Vin == vin, cancellationToken);
        }

        public async Task<bool> ExistsByRegistrationNumberAsync(string registrationNumber, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Vehicles
                .AnyAsync(v => v.RegistrationNumber == registrationNumber, cancellationToken);
        }

        public async Task<bool> ExistsByVinExceptIdAsync(string vin, Guid excludedVehicleId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Vehicles
                .AnyAsync(v => v.Vin == vin && v.Id != excludedVehicleId, cancellationToken);
        }

        public async Task<bool> ExistsByRegistrationNumberExceptIdAsync(string registrationNumber, Guid excludedVehicleId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Vehicles
                .AnyAsync(v => v.RegistrationNumber == registrationNumber && v.Id != excludedVehicleId, cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
