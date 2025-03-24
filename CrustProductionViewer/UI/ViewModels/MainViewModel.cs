using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrustProductionViewer.Core.Models.Analysis;
using CrustProductionViewer.Core.Models.GameData;
using CrustProductionViewer.Core.Services.DataAnalysis;
using CrustProductionViewer.Core.Services.MemoryReader;
using System.Collections.ObjectModel;
using System.Resources;
using System.Threading.Tasks;

namespace CrustProductionViewer.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IMemoryReader _memoryReader;
        private readonly IProductionAnalyzer _productionAnalyzer;

        [ObservableProperty]
        private bool _isConnectedToGame;

        [ObservableProperty]
        private ObservableCollection<Resource> _resources = new();

        [ObservableProperty]
        private ObservableCollection<Building> _buildings = new();

        [ObservableProperty]
        private ProductionAnalysis _currentProduction;

        [ObservableProperty]
        private OptimizationRecommendation _optimizationRecommendation;

        [ObservableProperty]
        private bool _isAnalyzing;

        public MainViewModel(IMemoryReader memoryReader, IProductionAnalyzer productionAnalyzer)
        {
            _memoryReader = memoryReader;
            _productionAnalyzer = productionAnalyzer;
        }

        [RelayCommand]
        private async Task ConnectToGameAsync()
        {
            IsConnectedToGame = await _memoryReader.ConnectToGameAsync();

            if (IsConnectedToGame)
            {
                await RefreshDataAsync();
                // Запустить таймер для периодического обновления данных
            }
        }

        [RelayCommand]
        private async Task RefreshDataAsync()
        {
            if (!IsConnectedToGame) return;

            var resourcesList = await _memoryReader.GetResourcesAsync();
            var buildingsList = await _memoryReader.GetBuildingsAsync();

            Resources = new ObservableCollection<Resource>(resourcesList);
            Buildings = new ObservableCollection<Building>(buildingsList);

            // Анализ производства
            IsAnalyzing = true;
            CurrentProduction = await _productionAnalyzer.AnalyzeCurrentProductionAsync(
                resourcesList, buildingsList);

            OptimizationRecommendation = await _productionAnalyzer.GetOptimizationRecommendationsAsync(
                CurrentProduction);
            IsAnalyzing = false;
        }
    }
}
