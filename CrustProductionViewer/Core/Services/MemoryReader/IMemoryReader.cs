using CrustProductionViewer.Core.Models.GameData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrustProductionViewer.Core.Services.MemoryReader
{
    public interface IMemoryReader
    {
        bool IsConnected { get; }
        Task<bool> ConnectToGameAsync();
        Task<List<Resource>> GetResourcesAsync();
        Task<List<Building>> GetBuildingsAsync();
        void Disconnect();
    }
}
