using CarRentalManagementSystem.Application.Abstractions.Repositories;
using CarRentalManagementSystem.Infrastructure.Data;
using CarRentalManagementSystem.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CarRentalDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBranchRepository, BranchRepository>();

            return services;
        }
    }
}
