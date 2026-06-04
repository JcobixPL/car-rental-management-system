using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
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
            ValidateRequest(request);

            var branchExists = await _branchRepository.ExistsByCityAndAddressAsync(
                request.City, 
                request.Address, 
                cancellationToken);

            if (branchExists)
                throw new ConflictException("Branch with the same city and address already exists.");

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

        private static void ValidateRequest(CreateBranchRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.City))
            {
                throw new ValidationException("City is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Address))
            {
                throw new ValidationException("Address is required.");
            }

            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                throw new ValidationException("Phone number is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ValidationException("Email is required.");
            }

            if (!request.Email.Contains('@'))
            {
                throw new ValidationException("Email has invalid format.");
            }
        }
    }
}
