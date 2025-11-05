using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.DataAccess.Entities
{
    /// <summary>
    /// Represents a predictive action to be taken based on a decision record.
    /// </summary>
    public class PredictiveAction
    {
        public int Id { get; set; }
        public int DecisionRecordId { get; set; }
        public string ActionDescription { get; set; } = string.Empty;
        public string Responsible { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation property for the parent decision record
        [ForeignKey("DecisionRecordId")]
        public DecisionRecord? DecisionRecord { get; set; }
    }
}
