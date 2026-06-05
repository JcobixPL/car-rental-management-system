using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.Update
{
    public sealed class UpdateBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public UpdateBranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task UpdateAsync(
            Guid id,
            UpdateBranchRequest request,
            CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);

            var branch = await _branchRepository.GetByIdAsync(id, cancellationToken);

            if (branch is null)
                throw new NotFoundException("Branch was not found.");

            branch.UpdateDetails(
                request.City,
                request.Address,
                request.PhoneNumber,
                request.Email);

            await _branchRepository.SaveChangesAsync(cancellationToken);
        }

        private static void ValidateRequest(UpdateBranchRequest request)
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
