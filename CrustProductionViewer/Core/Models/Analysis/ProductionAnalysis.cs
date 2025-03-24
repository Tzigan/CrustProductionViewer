using CrustProductionViewer.Core.Models.GameData;
using System;
using System.Collections.Generic;

namespace CrustProductionViewer.Core.Models.Analysis
{
    public class ProductionAnalysis
    {
        public List<Resource> Resources { get; set; } = new List<Resource>();
        public List<Building> Buildings { get; set; } = new List<Building>();
        public Dictionary<int, double> ResourceNetProduction { get; set; } =
            new Dictionary<int, double>(); // Ресурс ID -> Чистое производство
        public List<ProductionChain> ProductionChains { get; set; } =
            new List<ProductionChain>();
        public DateTime Timestamp { get; set; }
    }

    public class ProductionChain
    {
        public List<Building> Producers { get; set; } = new List<Building>();
        public List<Building> Consumers { get; set; } = new List<Building>();
        public int MainResourceId { get; set; }
        public double Efficiency { get; set; } // 0-1, где 1 - идеальный баланс
    }
}
