using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.DataAccess.Entities
{
    /// <summary>
    /// Records a significant decision made regarding an asset.
    /// </summary>
    public class DecisionRecord
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string DecisionText { get; set; } = string.Empty;
        public DateTime DecisionDate { get; set; }
        public string Outcome { get; set; } = string.Empty;

        // Navigation property for the parent asset
        [ForeignKey("AssetId")]
        public Asset? Asset { get; set; }

        // Navigation property for related predictive actions
        public ICollection<PredictiveAction> PredictiveActions { get; set; } = new List<PredictiveAction>();
    }
}
