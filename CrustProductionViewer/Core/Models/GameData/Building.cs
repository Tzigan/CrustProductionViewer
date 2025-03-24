using System.Collections.Generic;

namespace CrustProductionViewer.Core.Models.GameData
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int Count { get; set; }
        public List<ResourceFlow> Inputs { get; set; } = new List<ResourceFlow>();
        public List<ResourceFlow> Outputs { get; set; } = new List<ResourceFlow>();
    }

    public class ResourceFlow
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public double AmountPerMinute { get; set; }
    }
}
