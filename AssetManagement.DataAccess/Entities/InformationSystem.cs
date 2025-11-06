using System.Collections.Generic;

namespace AssetManagement.DataAccess.Entities
{
    // Represents an information system that supports asset management.
    public class InformationSystem
    {
        public int Id { get; set; }
        public string SystemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation property for related DataAssets
        public ICollection<DataAsset> DataAssets { get; set; } = new List<DataAsset>();
    }
}
