using CarRentalManagementSystem.Application.Branches.CreateBranch;
using CarRentalManagementSystem.Application.Branches.Get;
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

            return services;
        }
    }
}