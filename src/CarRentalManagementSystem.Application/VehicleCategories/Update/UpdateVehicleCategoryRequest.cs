using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.Update
{
    public sealed record UpdateVehicleCategoryRequest(
        string Code,
        string Name,
        TransmissionType TransmissionType,
        string Description);
}
