using System;
using System.Collections.Generic;

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

        // Foreign key for OrganisationalObjective
        public int OrganisationalObjectiveId { get; set; }
        public OrganisationalObjective? OrganisationalObjective { get; set; }

        // Navigation property for related Activities
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
