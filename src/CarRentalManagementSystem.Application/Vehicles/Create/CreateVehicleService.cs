using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Application.Common.Exceptions;
using CarRentalManagementSystem.Domain.Entities.Vehicles;

namespace CarRentalManagementSystem.Application.Vehicles.Create
{
    public sealed class CreateVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;
        private readonly IBranchRepository _branchRepository;

        public CreateVehicleService(IVehicleRepository vehicleRepository, IVehicleCategoryRepository vehicleCategoryRepository, IBranchRepository branchRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleCategoryRepository = vehicleCategoryRepository;
            _branchRepository = branchRepository;
        }

        public async Task<VehicleResponse> CreateAsync(
            CreateVehicleRequest request,
            CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);

            var vehicleCategory = await _vehicleCategoryRepository.GetByIdAsync(
                request.VehicleCategoryId,
                cancellationToken);

            if (vehicleCategory is null)
                throw new NotFoundException("Vehicle category was not found.");

            var branch = await _branchRepository.GetByIdAsync(
                request.CurrentBranchId,
                cancellationToken);

            if (branch is null)
                throw new NotFoundException("Branch was not found.");

            var vinExists = await _vehicleRepository.ExistsByVinAsync(
                request.Vin,
                cancellationToken);

            if (vinExists)
                throw new ConflictException("Vehicle with given VIN already exists.");

            var registrationNumber = await _vehicleRepository.ExistsByRegistrationNumberAsync(
                request.RegistrationNumber,
                cancellationToken);

            if (registrationNumber)
                throw new ConflictException("Vehicle with given registration number already exists.");

            var vehicle = new Vehicle(
                request.Vin,
                request.RegistrationNumber,
                request.Brand,
                request.Model,
                request.ProductionYear,
                request.VehicleCategoryId,
                request.CurrentBranchId,
                request.CurrentMileage,
                request.FuelType,
                request.TransmissionType,
                request.NextTechnicalInspectionDate,
                request.NextServiceMileage,
                request.NextServiceDate);

            await _vehicleRepository.AddAsync(vehicle, cancellationToken);
            await _vehicleRepository.SaveChangesAsync(cancellationToken);

            return new VehicleResponse(
                vehicle.Id,
                vehicle.Vin,
                vehicle.RegistrationNumber,
                vehicle.Brand,
                vehicle.Model,
                vehicle.ProductionYear,
                vehicle.VehicleCategoryId,
                vehicle.CurrentBranchId,
                vehicle.CurrentMileage,
                vehicle.FuelType,
                vehicle.TransmissionType,
                vehicle.OperationalStatus,
                vehicle.NextTechnicalInspectionDate,
                vehicle.NextServiceMileage,
                vehicle.NextServiceDate);
        }

        private static void ValidateRequest(CreateVehicleRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Vin))
            {
                throw new ValidationException("VIN is required.");
            }

            if (request.Vin.Length != 17)
            {
                throw new ValidationException("VIN must have exactly 17 characters.");
            }

            if (string.IsNullOrWhiteSpace(request.RegistrationNumber))
            {
                throw new ValidationException("Registration number is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Brand))
            {
                throw new ValidationException("Make is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Model))
            {
                throw new ValidationException("Model is required.");
            }

            if (request.ProductionYear < 1950)
            {
                throw new ValidationException("Production year is invalid.");
            }

            if (request.CurrentMileage < 0)
            {
                throw new ValidationException("Current mileage cannot be negative.");
            }

            if (request.NextServiceMileage <= request.CurrentMileage)
            {
                throw new ValidationException("Next service mileage must be greater than current mileage.");
            }
        }
    }
}
