using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Domain.Entities.Vehicles
{
    public sealed class Vehicle
    {
        public Guid Id { get; private set; }
        public string Vin { get; private set; } = string.Empty;
        public string RegistrationNumber { get; private set; } = string.Empty;
        public string Brand { get; private set; } = string.Empty;
        public string Model { get; private set; } = string.Empty;
        public int ProductionYear { get; private set; }
        public Guid VehicleCategoryId { get; private set; }
        public Guid CurrentBranchId { get; private set; }
        public int CurrentMileage { get; private set; }
        public FuelType FuelType { get; private set; }
        public TransmissionType TransmissionType { get; private set; }
        public VehicleOperationalStatus OperationalStatus { get; private set; }
        public DateOnly NextTechnicalInspectionDate { get; private set; }
        public int NextServiceMileage { get; private set; }
        public DateOnly NextServiceDate { get; private set; }

        private Vehicle() { }

        public Vehicle(
            string vin,
            string registrationNumber,
            string brand,
            string model,
            int productionYear,
            Guid vehicleCategoryId,
            Guid currentBranchId,
            int currentMileage,
            FuelType fuelType,
            TransmissionType transmissionType,
            DateOnly nextTechnicalInspectionDate,
            int nextServiceMileage,
            DateOnly nextServiceDate)
        {
            Id = Guid.NewGuid();
            Vin = vin;
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            VehicleCategoryId = vehicleCategoryId;
            CurrentBranchId = currentBranchId;
            CurrentMileage = currentMileage;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            OperationalStatus = VehicleOperationalStatus.Active;
            NextTechnicalInspectionDate = nextTechnicalInspectionDate;
            NextServiceMileage = nextServiceMileage;
            NextServiceDate = nextServiceDate;
        }

        public void UpdateDetails(
            string vin,
            string registrationNumber,
            string brand,
            string model,
            int productionYear,
            Guid vehicleCategoryId,
            Guid currentBranchId,
            FuelType fuelType,
            TransmissionType transmissionType,
            DateOnly nextTechnicalInspectionDate,
            int nextServiceMileage,
            DateOnly nextServiceDate)
        {
            Vin = vin;
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            VehicleCategoryId = vehicleCategoryId;
            CurrentBranchId = currentBranchId;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            NextTechnicalInspectionDate = nextTechnicalInspectionDate;
            NextServiceMileage = nextServiceMileage;
            NextServiceDate = nextServiceDate;
        }

        public void UpdateMileage(int currentMileage)
        {
            CurrentMileage = currentMileage;
        }

        public void Withdraw()
        {
            OperationalStatus = VehicleOperationalStatus.Withdrawn;
        }
    }
}
