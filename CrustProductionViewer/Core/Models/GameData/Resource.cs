namespace CrustProductionViewer.Core.Models.GameData
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public double Amount { get; set; }
        public double ProductionRate { get; set; } // Ресурсов в минуту
    }
}
