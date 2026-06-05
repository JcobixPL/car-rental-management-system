using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.Update
{
    public sealed record UpdateBranchRequest(
        string City,
        string Address,
        string PhoneNumber,
        string Email);
}
