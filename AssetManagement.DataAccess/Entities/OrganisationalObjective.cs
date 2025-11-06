using System.Collections.Generic;

namespace AssetManagement.DataAccess.Entities
{
    // Represents an organisational objective that provides a line-of-sight to asset objectives.
    public class OrganisationalObjective
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation property for related AssetObjectives
        public ICollection<AssetObjective> AssetObjectives { get; set; } = new List<AssetObjective>();
    }
}
