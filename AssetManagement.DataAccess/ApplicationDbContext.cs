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
        public DbSet<OrganisationalObjective> OrganisationalObjectives { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DataAsset> DataAssets { get; set; }
        public DbSet<InformationSystem> InformationSystems { get; set; }
        public DbSet<RiskItem> RiskItems { get; set; }
        public DbSet<AuditFinding> AuditFindings { get; set; }

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

            // Configure the one-to-many relationship between OrganisationalObjective and AssetObjective
            modelBuilder.Entity<OrganisationalObjective>()
                .HasMany(o => o.AssetObjectives)
                .WithOne(a => a.OrganisationalObjective)
                .HasForeignKey(a => a.OrganisationalObjectiveId);

            // Configure the one-to-many relationship between Asset and Activity
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.Activities)
                .WithOne(ac => ac.Asset)
                .HasForeignKey(ac => ac.AssetId);

            // Configure the one-to-many relationship between AssetObjective and Activity
            modelBuilder.Entity<AssetObjective>()
                .HasMany(ao => ao.Activities)
                .WithOne(ac => ac.AssetObjective)
                .HasForeignKey(ac => ac.AssetObjectiveId);

            // Configure the one-to-many relationship between InformationSystem and DataAsset
            modelBuilder.Entity<InformationSystem>()
                .HasMany(i => i.DataAssets)
                .WithOne(d => d.InformationSystem)
                .HasForeignKey(d => d.InformationSystemId);

            // Configure the one-to-many relationship between Asset and RiskItem
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.RiskItems)
                .WithOne(r => r.Asset)
                .HasForeignKey(r => r.AssetId);

            // Configure the one-to-many relationship between Activity and RiskItem
            modelBuilder.Entity<Activity>()
                .HasMany(a => a.RiskItems)
                .WithOne(r => r.Activity)
                .HasForeignKey(r => r.ActivityId);

            // Configure the one-to-many relationship between Asset and AuditFinding
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.AuditFindings)
                .WithOne(af => af.Asset)
                .HasForeignKey(af => af.AssetId);

            // Configure the one-to-many relationship between DecisionRecord and AuditFinding
            modelBuilder.Entity<DecisionRecord>()
                .HasMany(d => d.AuditFindings)
                .WithOne(af => af.DecisionRecord)
                .HasForeignKey(af => af.DecisionRecordId);
        }
    }
}
