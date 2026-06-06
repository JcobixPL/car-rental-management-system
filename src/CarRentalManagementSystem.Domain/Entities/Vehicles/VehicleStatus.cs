using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Domain.Entities.Vehicles
{
    public enum VehicleStatus
    {
        Available = 1,
        Reserved = 2,
        Rented = 3,
        Unavailable = 4,
        Withdrawn = 5
    }
}
