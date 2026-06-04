using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Domain.Entities.Branches;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.CreateBranch
{
    public sealed class CreateBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public CreateBranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BranchResponse> CreateAsync(
            CreateBranchRequest request,
            CancellationToken cancellationToken = default)
        {
            var branchExists = await _branchRepository.ExistsByCityAndAddressAsync(
                request.City, 
                request.Address, 
                cancellationToken);

            if (branchExists)
                throw new InvalidOperationException("Branch with given city and address already exists.");

            var branch = new Branch(
                request.City,
                request.Address,
                request.PhoneNumber,
                request.Email);

            await _branchRepository.AddAsync(branch, cancellationToken);
            await _branchRepository.SaveChangesAsync(cancellationToken);

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
