using System.Collections.Generic;

namespace AssetManagement.DataAccess.Entities
{
    // Represents an activity related to an asset and its objectives.
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Foreign key for Asset
        public int AssetId { get; set; }
        public Asset? Asset { get; set; }

        // Foreign key for AssetObjective
        public int AssetObjectiveId { get; set; }
        public AssetObjective? AssetObjective { get; set; }

        // Navigation property for related RiskItems
        public ICollection<RiskItem> RiskItems { get; set; } = new List<RiskItem>();
    }
}
