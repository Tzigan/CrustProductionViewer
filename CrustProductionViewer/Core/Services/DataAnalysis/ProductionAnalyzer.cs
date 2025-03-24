using CrustProductionViewer.Core.Models.Analysis;
using CrustProductionViewer.Core.Models.GameData;
using CrustProductionViewer.Core.Services.DataAnalysis;
using CrustProductionViewer.Core.Services.MemoryReader;
using System.Collections.Generic;
using System.Linq;

namespace CrustProductionViewer.Core.Services.DataAnalysis
{
    public class ProductionAnalyzer : IProductionAnalyzer
    {
        private readonly IMemoryReader _memoryReader;

        public ProductionAnalyzer(IMemoryReader memoryReader)
        {
            _memoryReader = memoryReader;
        }

        public Dictionary<int, ResourceFlow> AnalyzeResourceFlows()
        {
            var resources = _memoryReader.GetResources().ToDictionary(r => r.Id);
            var productionLines = _memoryReader.GetProductionLines();

            var resourceFlows = new Dictionary<int, ResourceFlow>();

            // Создаем объект ResourceFlow для каждого ресурса
            foreach (var resource in resources.Values)
            {
                resourceFlows[resource.Id] = new ResourceFlow
                {
                    ResourceId = resource.Id,
                    ResourceName = resource.Name,
                    CurrentAmount = resource.Quantity,
                    MaxAmount = resource.MaxStorage,
                    InputRate = 0,
                    OutputRate = 0
                };
            }

            // Анализируем входящие и исходящие потоки для каждой производственной линии
            foreach (var line in productionLines)
            {
                var building = _memoryReader.GetBuildings().FirstOrDefault(b => b.Id == line.BuildingId);
                if (building == null) continue;

                float buildingCount = building.Count;
                float efficiency = line.EfficiencyFactor;

                // Обрабатываем входящие ресурсы (потребление)
                foreach (var input in line.InputResources)
                {
                    if (resourceFlows.ContainsKey(input.ResourceId))
                    {
                        resourceFlows[input.ResourceId].OutputRate += input.Amount * buildingCount * efficiency;
                    }
                }

                // Обрабатываем исходящие ресурсы (производство)
                foreach (var output in line.OutputResources)
                {
                    if (resourceFlows.ContainsKey(output.ResourceId))
                    {
                        resourceFlows[output.ResourceId].InputRate += output.Amount * buildingCount * efficiency;
                    }
                }
            }

            return resourceFlows;
        }

        public List<ProductionNode> BuildProductionNetwork()
        {
            var productionLines = _memoryReader.GetProductionLines();
            var buildings = _memoryReader.GetBuildings().ToDictionary(b => b.Id);
            var nodes = new List<ProductionNode>();

            foreach (var line in productionLines)
            {
                var node = new ProductionNode
                {
                    ProductionId = line.Id,
                    ProductionName = line.Name,
                    BuildingId = line.BuildingId,
                    BuildingName = buildings.ContainsKey(line.BuildingId) ? buildings[line.BuildingId].Name : "Неизвестно",
                    BuildingCount = buildings.ContainsKey(line.BuildingId) ? buildings[line.BuildingId].Count : 0,
                    Efficiency = line.EfficiencyFactor,
                    InputResources = line.InputResources.Select(ir => new ResourceNode { ResourceId = ir.ResourceId, Amount = ir.Amount }).ToList(),
                    OutputResources = line.OutputResources.Select(or => new ResourceNode { ResourceId = or.ResourceId, Amount = or.Amount }).ToList()
                };

                nodes.Add(node);
            }

            return nodes;
        }

        public OptimalBuild CalculateOptimalBuild(int targetResourceId, float desiredRate)
        {
            // В заглушке просто возвращаем тестовые данные
            var resources = _memoryReader.GetResources().ToDictionary(r => r.Id);
            var buildings = _memoryReader.GetBuildings().ToDictionary(b => b.Id);

            var optimalBuild = new OptimalBuild
            {
                TargetResourceId = targetResourceId,
                TargetResourceName = resources.ContainsKey(targetResourceId) ? resources[targetResourceId].Name : "Неизвестный ресурс",
                DesiredRate = desiredRate,
                BuildingRecommendations = new List<BuildingRecommendation>
                {
                    new BuildingRecommendation
                    {
                        BuildingId = 1,
                        BuildingName = buildings.ContainsKey(1) ? buildings[1].Name : "Шахта железа",
                        CurrentCount = buildings.ContainsKey(1) ? buildings[1].Count : 2,
                        RecommendedCount = 3,
                        DeltaCount = 1
                    },
                    new BuildingRecommendation
                    {
                        BuildingId = 2,
                        BuildingName = buildings.ContainsKey(2) ? buildings[2].Name : "Фабрика металла",
                        CurrentCount = buildings.ContainsKey(2) ? buildings[2].Count : 1,
                        RecommendedCount = 2,
                        DeltaCount = 1
                    }
                },
                BottleneckResources = new List<BottleneckResource>
                {
                    new BottleneckResource
                    {
                        ResourceId = 1,
                        ResourceName = "Железо",
                        CurrentRate = 20,
                        RequiredRate = 25,
                        Deficit = 5
                    }
                }
            };

            return optimalBuild;
        }
    }
}
