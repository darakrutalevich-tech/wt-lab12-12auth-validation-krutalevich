using Microsoft.EntityFrameworkCore;
using wt_lab12_12auth_validation_krutalevich.Models;

namespace wt_lab12_12auth_validation_krutalevich.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<User> Users => Set<User>();
    }
}
