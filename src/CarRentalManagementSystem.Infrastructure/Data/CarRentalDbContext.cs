using CarRentalManagementSystem.Domain.Entities.Branches;
using CarRentalManagementSystem.Domain.Entities.VehicleCategories;
using CarRentalManagementSystem.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Infrastructure.Data
{
    public sealed class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
        }

        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<VehicleCategory> VehicleCategories => Set<VehicleCategory>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarRentalDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
