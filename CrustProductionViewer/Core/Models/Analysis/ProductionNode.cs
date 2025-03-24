using System.Collections.Generic;

namespace CrustProductionViewer.Core.Models.Analysis
{
    public class ProductionNode
    {
        public int ProductionId { get; set; }
        public string ProductionName { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public int BuildingCount { get; set; }
        public float Efficiency { get; set; }
        public List<ResourceNode> InputResources { get; set; } = new List<ResourceNode>();
        public List<ResourceNode> OutputResources { get; set; } = new List<ResourceNode>();
    }

    public class ResourceNode
    {
        public int ResourceId { get; set; }
        public float Amount { get; set; }
    }
}
