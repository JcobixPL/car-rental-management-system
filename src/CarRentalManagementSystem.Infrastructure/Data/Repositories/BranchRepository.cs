using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Infrastructure.Data.Repositories
{
    public sealed class BranchRepository : IBranchRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public BranchRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            await _dbContext.Branches.AddAsync(branch, cancellationToken);
        }

        public async Task<IReadOnlyList<Branch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Branches
                .AsNoTracking()
                .OrderBy(b => b.City)
                .ThenBy(b => b.Address)
                .ToListAsync(cancellationToken);
        }

        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Branches
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsByCityAndAddressAsync(string city, string address, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Branches
                .AnyAsync(b => b.City == city && b.Address == address, cancellationToken);
        }

        public async Task<bool> ExistsByCityAndAddressExceptIdAsync(string city, string address, Guid excludedBranchId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Branches
                .AnyAsync(b => b.City == city && b.Address == address && b.Id != excludedBranchId, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
