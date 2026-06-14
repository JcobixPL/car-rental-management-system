using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Vehicles.Update
{
    public sealed class UpdateVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;
        private readonly IBranchRepository _branchRepository;

        public UpdateVehicleService(
            IVehicleRepository vehicleRepository,
            IVehicleCategoryRepository vehicleCategoryRepository,
            IBranchRepository branchRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleCategoryRepository = vehicleCategoryRepository;
            _branchRepository = branchRepository;
        }

        public async Task UpdateAsync(
            Guid id,
            UpdateVehicleRequest request,
            CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);

            var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

            if (vehicle is null)
                throw new NotFoundException("Vehicle was not found.");

            var vehicleCategory = await _vehicleCategoryRepository.GetByIdAsync(vehicle.VehicleCategoryId, cancellationToken);

            if (vehicleCategory is null)
                throw new NotFoundException("Vehicle category was not found.");

            var branch = await _branchRepository.GetByIdAsync(vehicle.CurrentBranchId, cancellationToken);

            if (branch is null)
                throw new NotFoundException("Branch was not found.");

            var registrationNumberExists = await _vehicleRepository.ExistsByRegistrationNumberExceptIdAsync(
                request.RegistrationNumber,
                id,
                cancellationToken);

            if (registrationNumberExists)
                throw new ConflictException("Vehicle with given registration number already exists.");

            vehicle.UpdateDetails(
                request.Vin,
                request.RegistrationNumber,
                request.Brand,
                request.Model,
                request.ProductionYear,
                request.VehicleCategoryId,
                request.CurrentBranchId,
                request.FuelType,
                request.TransmissionType,
                request.NextTechnicalInspectionDate,
                request.NextServiceMileage,
                request.NextServiceDate);

            await _vehicleRepository.SaveChangesAsync(cancellationToken);
        }

        private static void ValidateRequest(UpdateVehicleRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.RegistrationNumber))
            {
                throw new ValidationException("Registration number is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Brand))
            {
                throw new ValidationException("Brand is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Model))
            {
                throw new ValidationException("Model is required.");
            }

            if (request.ProductionYear < 1950)
            {
                throw new ValidationException("Production year is invalid.");
            }

            if (request.NextServiceMileage <= 0)
            {
                throw new ValidationException(
                    "Next service mileage must be greater than zero.");
            }
        }

    }
}
