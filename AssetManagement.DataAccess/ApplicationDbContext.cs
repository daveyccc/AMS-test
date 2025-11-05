using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
    }
}
