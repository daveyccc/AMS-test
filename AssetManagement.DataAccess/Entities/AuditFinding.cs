using System;

namespace AssetManagement.DataAccess.Entities
{
    // Represents an audit finding related to an asset or decision record.
    public class AuditFinding
    {
        public int Id { get; set; }
        public string ClauseReference { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        // Foreign key for Asset (optional)
        public int? AssetId { get; set; }
        public Asset? Asset { get; set; }

        // Foreign key for DecisionRecord (optional)
        public int? DecisionRecordId { get; set; }
        public DecisionRecord? DecisionRecord { get; set; }
    }
}
