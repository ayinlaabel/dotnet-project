using salvage_portal.Models;
using Microsoft.EntityFrameworkCore;

namespace salvage_portal.Data
{
    public class salvagePortalDbContext : DbContext
    {
        public salvagePortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}