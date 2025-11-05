using System;

namespace AssetManagement.DataAccess.Entities
{
    /// <summary>
    /// Represents a strategic objective related to an asset.
    /// </summary>
    public class AssetObjective
    {
        public int Id { get; set; }
        public string ObjectiveText { get; set; } = string.Empty;
        public DateTime TargetDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
