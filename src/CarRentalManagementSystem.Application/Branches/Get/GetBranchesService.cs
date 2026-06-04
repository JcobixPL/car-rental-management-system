using CarRentalManagementSystem.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.Get
{
    public sealed class GetBranchesService
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchesService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IReadOnlyList<BranchResponse>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var branches = await _branchRepository.GetAllAsync(cancellationToken);

            return branches
                .Select(b => new BranchResponse(
                    b.Id,
                    b.City,
                    b.Address,
                    b.PhoneNumber,
                    b.Email,
                    b.IsActive))
                .ToList();
        }
    }
}
