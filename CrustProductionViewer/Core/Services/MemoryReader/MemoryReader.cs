using CrustProductionViewer.Core.Models.GameData;
using CrustProductionViewer.Core.Services.MemoryReader;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;

namespace CrustProductionViewer.Core.Services.MemoryReader
{
    public class MemoryReader : IMemoryReader
    {
        public event EventHandler<GameDataUpdatedEventArgs> GameDataUpdated;

        public bool IsConnected { get; private set; } = false;

        public bool ConnectToGame()
        {
            // В заглушке просто имитируем успешное подключение
            IsConnected = true;
            return true;
        }

        public void Disconnect()
        {
            IsConnected = false;
        }

        public IEnumerable<Resource> GetResources()
        {
            // Тестовые данные для ресурсов
            return new List<Resource>
            {
                new Resource { Id = 1, Name = "Железо", Quantity = 100, MaxStorage = 1000 },
                new Resource { Id = 2, Name = "Медь", Quantity = 75, MaxStorage = 500 },
                new Resource { Id = 3, Name = "Кремний", Quantity = 50, MaxStorage = 300 },
                new Resource { Id = 4, Name = "Кислород", Quantity = 200, MaxStorage = 2000 }
            };
        }

        public IEnumerable<Building> GetBuildings()
        {
            // Тестовые данные для зданий
            return new List<Building>
            {
                new Building { Id = 1, Name = "Шахта железа", Count = 2, ProductionRate = 10 },
                new Building { Id = 2, Name = "Фабрика металла", Count = 1, ProductionRate = 5 },
                new Building { Id = 3, Name = "Электростанция", Count = 3, ProductionRate = 15 }
            };
        }

        public IEnumerable<Production> GetProductionLines()
        {
            // Тестовые данные для производственных линий
            return new List<Production>
            {
                new Production
                {
                    Id = 1,
                    Name = "Производство металла",
                    InputResources = new List<ResourceAmount> { new ResourceAmount { ResourceId = 1, Amount = 5 } },
                    OutputResources = new List<ResourceAmount> { new ResourceAmount { ResourceId = 5, Amount = 1 } },
                    BuildingId = 2,
                    EfficiencyFactor = 0.9f
                },
                new Production
                {
                    Id = 2,
                    Name = "Добыча железа",
                    InputResources = new List<ResourceAmount>(),
                    OutputResources = new List<ResourceAmount> { new ResourceAmount { ResourceId = 1, Amount = 10 } },
                    BuildingId = 1,
                    EfficiencyFactor = 1.0f
                }
            };
        }

        public PlayerStats GetPlayerStats()
        {
            // Тестовые данные для статистики игрока
            return new PlayerStats
            {
                Money = 50000,
                ResearchPoints = 250,
                ColonistsCount = 35,
                ColonistsSatisfaction = 0.75f
            };
        }

        public void StartDataCollection()
        {
            // Имитация периодического обновления данных
            System.Threading.Tasks.Task.Run(async () =>
            {
                while (IsConnected)
                {
                    // Имитируем обновление данных
                    GameDataUpdated?.Invoke(this, new GameDataUpdatedEventArgs());
                    await System.Threading.Tasks.Task.Delay(5000); // Обновление каждые 5 секунд
                }
            });
        }

        public void StopDataCollection()
        {
            IsConnected = false;
        }
    }

    public class GameDataUpdatedEventArgs : EventArgs
    {
        // В реальной реализации здесь могут быть данные об обновлении
    }
}
