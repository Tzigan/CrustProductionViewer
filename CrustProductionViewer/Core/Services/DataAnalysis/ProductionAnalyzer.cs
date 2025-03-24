using CrustProductionViewer.Core.Models.Analysis;
using CrustProductionViewer.Core.Models.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustProductionViewer.Core.Services.DataAnalysis
{
    public class ProductionAnalyzer : IProductionAnalyzer
    {
        public async Task<ProductionAnalysis> AnalyzeCurrentProductionAsync(
            List<Resource> resources, List<Building> buildings)
        {
            // TODO: Реализовать реальный анализ
            await Task.Delay(500); // Имитация сложных вычислений

            var analysis = new ProductionAnalysis
            {
                Resources = resources,
                Buildings = buildings,
                Timestamp = DateTime.Now
            };

            // Рассчитываем чистое производство для каждого ресурса
            foreach (var resource in resources)
            {
                double totalProduction = 0;
                double totalConsumption = 0;

                foreach (var building in buildings)
                {
                    // Производство
                    var output = building.Outputs.FirstOrDefault(o => o.ResourceId == resource.Id);
                    if (output != null)
                    {
                        totalProduction += output.AmountPerMinute * building.Count;
                    }

                    // Потребление
                    var input = building.Inputs.FirstOrDefault(i => i.ResourceId == resource.Id);
                    if (input != null)
                    {
                        totalConsumption += input.AmountPerMinute * building.Count;
                    }
                }

                // Чистое производство
                analysis.ResourceNetProduction[resource.Id] = totalProduction - totalConsumption;
            }

            // Простейшие производственные цепочки
            // В реальном приложении это будет более сложный алгоритм
            var productionChains = new List<ProductionChain>();
            foreach (var resource in resources)
            {
                var producers = buildings.Where(b =>
                    b.Outputs.Any(o => o.ResourceId == resource.Id)).ToList();

                var consumers = buildings.Where(b =>
                    b.Inputs.Any(i => i.ResourceId == resource.Id)).ToList();

                if (producers.Count > 0 || consumers.Count > 0)
                {
                    double totalProduction = producers.Sum(p =>
                        p.Outputs.First(o => o.ResourceId == resource.Id).AmountPerMinute * p.Count);

                    double totalConsumption = consumers.Sum(c =>
                        c.Inputs.First(i => i.ResourceId == resource.Id).AmountPerMinute * c.Count);

                    double efficiency = 0;
                    if (totalProduction > 0 && totalConsumption > 0)
                    {
                        efficiency = Math.Min(totalProduction / totalConsumption,
                                             totalConsumption / totalProduction);
                    }

                    productionChains.Add(new ProductionChain
                    {
                        Producers = producers,
                        Consumers = consumers,
                        MainResourceId = resource.Id,
                        Efficiency = efficiency
                    });
                }
            }

            analysis.ProductionChains = productionChains;
            return analysis;
        }

        public async Task<OptimizationRecommendation> GetOptimizationRecommendationsAsync(
            ProductionAnalysis currentProduction)
        {
            // TODO: Реализовать реальный алгоритм оптимизации
            await Task.Delay(800); // Имитация сложных вычислений

            var recommendation = new OptimizationRecommendation
            {
                GeneralRecommendations = new List<string>(),
                RecommendedBuildings = new List<BuildingRecommendation>(),
                EfficiencyImprovement = 0.15 // Тестовое значение
            };

            // Примеры рекомендаций на основе тестовых данных
            foreach (var chain in currentProduction.ProductionChains)
            {
                var resourceName = currentProduction.Resources
                    .FirstOrDefault(r => r.Id == chain.MainResourceId)?.Name ?? "Неизвестный ресурс";

                if (chain.Efficiency < 0.8)
                {
                    if (chain.Producers.Count > 0 && chain.Consumers.Count > 0)
                    {
                        var totalProduction = chain.Producers.Sum(p =>
                            p.Outputs.First(o => o.ResourceId == chain.MainResourceId).AmountPerMinute * p.Count);

                        var totalConsumption = chain.Consumers.Sum(c =>
                            c.Inputs.First(i => i.ResourceId == chain.MainResourceId).AmountPerMinute * c.Count);

                        if (totalProduction < totalConsumption)
                        {
                            // Не хватает производства
                            var mainProducer = chain.Producers[0];
                            var productionPerBuilding = mainProducer.Outputs
                                .First(o => o.ResourceId == chain.MainResourceId).AmountPerMinute;

                            var deficit = totalConsumption - totalProduction;
                            var buildingsNeeded = (int)Math.Ceiling(deficit / productionPerBuilding);

                            recommendation.RecommendedBuildings.Add(new BuildingRecommendation
                            {
                                BuildingId = mainProducer.Id,
                                BuildingName = mainProducer.Name,
                                RecommendedCount = buildingsNeeded,
                                Reason = $"Нехватка производства {resourceName} ({deficit:F1}/мин)"
                            });

                            recommendation.GeneralRecommendations.Add(
                                $"Добавьте {buildingsNeeded} {mainProducer.Name} для сбалансирования производства {resourceName}");
                        }
                        else
                        {
                            // Избыток производства
                            var mainConsumer = chain.Consumers.First();
                            var consumptionPerBuilding = mainConsumer.Inputs
                                .First(i => i.ResourceId == chain.MainResourceId).AmountPerMinute;

                            var excess = totalProduction - totalConsumption;
                            var buildingsNeeded = (int)Math.Ceiling(excess / consumptionPerBuilding);

                            recommendation.RecommendedBuildings.Add(new BuildingRecommendation
                            {
                                BuildingId = mainConsumer.Id,
                                BuildingName = mainConsumer.Name,
                                RecommendedCount = buildingsNeeded,
                                Reason = $"Избыток производства {resourceName} ({excess:F1}/мин)"
                            });

                            recommendation.GeneralRecommendations.Add(
                                $"Добавьте {buildingsNeeded} {mainConsumer.Name} для использования избытка {resourceName}");
                        }
                    }
                }
            }

            return recommendation;
        }
    }
}
