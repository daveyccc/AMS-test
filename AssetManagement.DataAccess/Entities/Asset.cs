using AssetManagement.DataAccess.Enums;
using System.Collections.Generic;

namespace AssetManagement.DataAccess.Entities
{
    /// <summary>
    /// Represents a physical or logical asset in the organization.
    /// </summary>
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public LifecycleStage LifecycleStage { get; set; }
        public RiskRating RiskRating { get; set; }

        // Navigation property for related decision records
        public ICollection<DecisionRecord> DecisionRecords { get; set; } = new List<DecisionRecord>();

        // Navigation property for related Activities
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

        // Navigation property for related RiskItems
        public ICollection<RiskItem> RiskItems { get; set; } = new List<RiskItem>();

        // Navigation property for related AuditFindings
        public ICollection<AuditFinding> AuditFindings { get; set; } = new List<AuditFinding>();
    }
}
