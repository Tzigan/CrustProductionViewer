using CrustProductionViewer.Infrastructure.DependencyInjection;
using CrustProductionViewer.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

namespace CrustProductionViewer
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public App()
        {
            this.InitializeComponent();

            Services = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.RegisterServices();
            return services.BuildServiceProvider();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();

            var rootFrame = new Microsoft.UI.Xaml.Controls.Frame();
            m_window.Content = rootFrame;
            rootFrame.Navigate(typeof(MainPage));
        }

        private Window m_window;
    }
}
