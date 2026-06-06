using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories
{
    public sealed record VehicleCategoryResponse(
        Guid Id,
        string Code,
        string Name,
        TransmissionType TransmissionType,
        string Description,
        bool IsActive);
}
