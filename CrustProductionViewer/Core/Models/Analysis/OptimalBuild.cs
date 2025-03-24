using System.Collections.Generic;

namespace CrustProductionViewer.Core.Models.Analysis
{
    public class OptimalBuild
    {
        public int TargetResourceId { get; set; }
        public string TargetResourceName { get; set; }
        public float DesiredRate { get; set; }
        public List<BuildingRecommendation> BuildingRecommendations { get; set; } = new List<BuildingRecommendation>();
        public List<BottleneckResource> BottleneckResources { get; set; } = new List<BottleneckResource>();
    }

    public class BuildingRecommendation
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public int CurrentCount { get; set; }
        public int RecommendedCount { get; set; }
        public int DeltaCount { get; set; }
    }

    public class BottleneckResource
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public float CurrentRate { get; set; }
        public float RequiredRate { get; set; }
        public float Deficit { get; set; }
    }
}
