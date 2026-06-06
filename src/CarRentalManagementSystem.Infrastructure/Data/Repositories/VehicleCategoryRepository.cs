using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Infrastructure.Data.Repositories
{
    public sealed class VehicleCategoryRepository : IVehicleCategoryRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public VehicleCategoryRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(VehicleCategory vehicleCategory, CancellationToken cancellationToken = default)
        {
            await _dbContext.VehicleCategories.AddAsync(vehicleCategory, cancellationToken);
        }

        public async Task<IReadOnlyList<VehicleCategory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.VehicleCategories
                .AsNoTracking()
                .OrderBy(vc => vc.Code)
                .ToListAsync(cancellationToken);
        }

        public async Task<VehicleCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.VehicleCategories.FirstOrDefaultAsync(vc => vc.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _dbContext.VehicleCategories.AnyAsync(vc => vc.Code == code, cancellationToken);
        }

        public async Task<bool> ExistsByCodeExceptIdAsync(string code, Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.VehicleCategories.AnyAsync(vc => vc.Id != id && vc.Code == code, cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
