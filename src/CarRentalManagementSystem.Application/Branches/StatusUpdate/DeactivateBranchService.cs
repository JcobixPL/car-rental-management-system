using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.StatusUpdate
{
    public sealed class DeactivateBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public DeactivateBranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task DeactivateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var branch = await _branchRepository.GetByIdAsync(id, cancellationToken);

            if (branch is null)
                throw new NotFoundException("Branch was not found.");

            branch.Deactivate();

            await _branchRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
