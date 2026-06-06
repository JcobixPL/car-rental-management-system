using CarRentalManagementSystem.Application.Branches.CreateBranch;
using CarRentalManagementSystem.Application.Branches.Get;
using CarRentalManagementSystem.Application.Branches.StatusUpdate;
using CarRentalManagementSystem.Application.Branches.Update;
using CarRentalManagementSystem.Application.VehicleCategories.Create;
using CarRentalManagementSystem.Application.VehicleCategories.Get;
using CarRentalManagementSystem.Application.VehicleCategories.StatusUpdate;
using CarRentalManagementSystem.Application.VehicleCategories.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Branches
            services.AddScoped<CreateBranchService>();
            services.AddScoped<GetBranchesService>();
            services.AddScoped<GetBranchByIdService>();
            services.AddScoped<UpdateBranchService>();
            services.AddScoped<ActivateBranchService>();
            services.AddScoped<DeactivateBranchService>();

            // Vehicle Categories
            services.AddScoped<CreateVehicleCategoryService>();
            services.AddScoped<GetVehicleCategoriesService>();
            services.AddScoped<GetVehicleCategoryByIdService>();
            services.AddScoped<UpdateVehicleCategoryService>();
            services.AddScoped<ActivateVehicleCategoryService>();
            services.AddScoped<DeactivateVehicleCategoryService>();

            return services;
        }
    }
}