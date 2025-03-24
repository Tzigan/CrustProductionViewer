using System.Collections.Generic;

namespace CrustProductionViewer.Core.Models.Analysis
{
    public class OptimizationRecommendation
    {
        public List<BuildingRecommendation> RecommendedBuildings { get; set; } =
            new List<BuildingRecommendation>();
        public List<string> GeneralRecommendations { get; set; } =
            new List<string>();
        public double EfficiencyImprovement { get; set; } // Предполагаемое улучшение эффективности
    }

    public class BuildingRecommendation
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public int RecommendedCount { get; set; }
        public string Reason { get; set; }
    }
}
