using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Branches.CreateBranch
{
    public sealed record CreateBranchRequest(
        string City,
        string Address,
        string PhoneNumber,
        string Email);
}
