using CarRentalManagementSystem.Application.Branches.CreateBranch;
using CarRentalManagementSystem.Application.Branches.Get;
using CarRentalManagementSystem.Application.Branches.StatusUpdate;
using CarRentalManagementSystem.Application.Branches.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateBranchService>();
            services.AddScoped<GetBranchesService>();
            services.AddScoped<GetBranchByIdService>();
            services.AddScoped<UpdateBranchService>();
            services.AddScoped<ActivateBranchService>();
            services.AddScoped<DeactivateBranchService>();

            return services;
        }
    }
}