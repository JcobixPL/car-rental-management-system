using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.CreateBranch
{
    public sealed record BranchResponse(
        Guid Id,
        string City,
        string Address,
        string PhoneNumber,
        string Email,
        bool IsActive);
}
