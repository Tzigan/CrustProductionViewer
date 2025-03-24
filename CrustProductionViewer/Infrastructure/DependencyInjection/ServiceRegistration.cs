using CrustProductionViewer.Core.Services.DataAnalysis;
using CrustProductionViewer.Core.Services.MemoryReader;
using CrustProductionViewer.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CrustProductionViewer.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Core Services
            services.AddSingleton<IMemoryReader, MemoryReader>(); // Создайте заглушку MemoryReader
            services.AddSingleton<IProductionAnalyzer, ProductionAnalyzer>(); // Создайте заглушку ProductionAnalyzer

            // ViewModels
            services.AddTransient<MainViewModel>();

            return services;
        }
    }
}
