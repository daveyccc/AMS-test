using System;

namespace AssetManagement.DataAccess.Entities
{
    // Represents metadata about asset data, including ownership, quality, and system information.
    public class DataAsset
    {
        public int Id { get; set; }
        public string DataOwner { get; set; } = string.Empty;
        public string DataQuality { get; set; } = string.Empty;
        public string SystemName { get; set; } = string.Empty;
        public DateTime LastReviewed { get; set; }

        // Foreign key for InformationSystem
        public int InformationSystemId { get; set; }
        public InformationSystem? InformationSystem { get; set; }
    }
}
