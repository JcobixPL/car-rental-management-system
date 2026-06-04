using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Infrastructure.Data
{
    public sealed class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
        }
    }
}
