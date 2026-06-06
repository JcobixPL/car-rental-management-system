using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Domain.Entities.VehicleCategories
{
    public sealed class VehicleCategory
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public TransmissionType TransmissionType { get; private set; }
        public bool IsActive { get; private set; }

        private VehicleCategory()
        { 
        }
    
        public VehicleCategory(
            string code,
            string name,
            string description,
            TransmissionType transmissionType)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Description = description;
            TransmissionType = transmissionType;
            IsActive = true;
        }

        public void UpdateDetails(
            string code,
            string name,
            string description,
            TransmissionType transmissionType)
        {
            Code = code;
            Name = name;
            Description = description;
            TransmissionType = transmissionType;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
