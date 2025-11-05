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
        public DbSet<AssetObjective> AssetObjectives { get; set; }
        public DbSet<DecisionRecord> DecisionRecords { get; set; }
        public DbSet<PredictiveAction> PredictiveActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between Asset and DecisionRecord
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.DecisionRecords)
                .WithOne(d => d.Asset)
                .HasForeignKey(d => d.AssetId);

            // Configure the one-to-many relationship between DecisionRecord and PredictiveAction
            modelBuilder.Entity<DecisionRecord>()
                .HasMany(d => d.PredictiveActions)
                .WithOne(p => p.DecisionRecord)
                .HasForeignKey(p => p.DecisionRecordId);
        }
    }
}
