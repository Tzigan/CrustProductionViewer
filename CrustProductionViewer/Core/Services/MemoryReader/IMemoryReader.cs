using CrustProductionViewer.Core.Models.GameData;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;

namespace CrustProductionViewer.Core.Services.MemoryReader
{
    public interface IMemoryReader
    {
        event EventHandler<GameDataUpdatedEventArgs> GameDataUpdated;

        bool IsConnected { get; }

        bool ConnectToGame();

        void Disconnect();

        IEnumerable<Resource> GetResources();

        IEnumerable<Building> GetBuildings();

        IEnumerable<Production> GetProductionLines();

        PlayerStats GetPlayerStats();

        void StartDataCollection();

        void StopDataCollection();
    }
}
