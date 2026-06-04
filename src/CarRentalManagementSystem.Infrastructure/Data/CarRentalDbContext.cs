using CarRentalManagementSystem.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Infrastructure.Data
{
    public sealed class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
        }

        public DbSet<Branch> Branches => Set<Branch>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarRentalDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
