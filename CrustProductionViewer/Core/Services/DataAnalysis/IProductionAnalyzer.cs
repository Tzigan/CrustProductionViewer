using CrustProductionViewer.Core.Models.Analysis;
using CrustProductionViewer.Core.Models.GameData;
using System.Collections.Generic;

namespace CrustProductionViewer.Core.Services.DataAnalysis
{
    public interface IProductionAnalyzer
    {
        Dictionary<int, ResourceFlow> AnalyzeResourceFlows();

        List<ProductionNode> BuildProductionNetwork();

        OptimalBuild CalculateOptimalBuild(int targetResourceId, float desiredRate);
    }
}
