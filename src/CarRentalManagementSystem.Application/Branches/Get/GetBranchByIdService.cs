using CarRentalManagementSystem.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.Get
{
    public sealed class GetBranchByIdService
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchByIdService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BranchResponse?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var branch = await _branchRepository.GetByIdAsync(id, cancellationToken);

            if (branch is null)
                return null;

            return new BranchResponse(
                branch.Id,
                branch.City,
                branch.Address,
                branch.PhoneNumber,
                branch.Email,
                branch.IsActive);
        }
    }
}
