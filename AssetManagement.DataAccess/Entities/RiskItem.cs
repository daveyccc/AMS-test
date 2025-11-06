namespace AssetManagement.DataAccess.Entities
{
    // Represents a risk item associated with an asset or activity.
    public class RiskItem
    {
        public int Id { get; set; }
        public string RiskType { get; set; } = string.Empty;
        public double Likelihood { get; set; }
        public double Impact { get; set; }
        public string MitigationPlan { get; set; } = string.Empty;

        // Foreign key for Asset (optional)
        public int? AssetId { get; set; }
        public Asset? Asset { get; set; }

        // Foreign key for Activity (optional)
        public int? ActivityId { get; set; }
        public Activity? Activity { get; set; }
    }
}
