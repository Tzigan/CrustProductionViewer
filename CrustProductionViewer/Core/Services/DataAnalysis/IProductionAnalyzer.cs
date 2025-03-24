using CrustProductionViewer.Core.Models.Analysis;
using CrustProductionViewer.Core.Models.GameData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrustProductionViewer.Core.Services.DataAnalysis
{
    public interface IProductionAnalyzer
    {
        Task<ProductionAnalysis> AnalyzeCurrentProductionAsync(
            List<Resource> resources, List<Building> buildings);
        Task<OptimizationRecommendation> GetOptimizationRecommendationsAsync(
            ProductionAnalysis currentProduction);
    }
}
