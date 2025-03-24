using System.Collections.Generic;

namespace CrustProductionViewer.Core.Models.GameData
{
    public class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public List<ResourceAmount> InputResources { get; set; } = new List<ResourceAmount>();
        public List<ResourceAmount> OutputResources { get; set; } = new List<ResourceAmount>();
        public float EfficiencyFactor { get; set; }
    }
}
