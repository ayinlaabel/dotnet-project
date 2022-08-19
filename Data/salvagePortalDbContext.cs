using salvage_portal.Models;
using Microsoft.EntityFrameworkCore;

namespace salvage_portal.Data
{
    public class SalvagePortalDbContext : DbContext
    {
        public SalvagePortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}