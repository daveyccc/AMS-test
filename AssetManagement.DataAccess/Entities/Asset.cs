namespace AssetManagement.DataAccess.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
