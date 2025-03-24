namespace CrustProductionViewer.Core.Models.GameData
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public float MaxStorage { get; set; }
    }

    public class ResourceAmount
    {
        public int ResourceId { get; set; }
        public float Amount { get; set; }
    }
}
