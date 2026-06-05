using CarRentalManagementSystem.Domain.Entities.Branches;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Abstractions.Repositories
{
    public interface IBranchRepository
    {
        Task AddAsync(Branch branch, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Branch>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> ExistsByCityAndAddressAsync(string city, string address, CancellationToken cancellationToken = default);

        Task<bool> ExistsByCityAndAddressExceptIdAsync(string city, string address, Guid excludedBranchId, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
