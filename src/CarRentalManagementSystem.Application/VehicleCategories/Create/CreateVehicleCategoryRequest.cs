using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.VehicleCategories.Create
{
    public sealed record CreateVehicleCategoryRequest(
        string Code,
        string Name,
        TransmissionType TransmissionType,
        string Description);
}
