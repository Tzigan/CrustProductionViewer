using CrustProductionViewer.UI.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace CrustProductionViewer.UI.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();
            // В реальном приложении ViewModel будет получена через DI
            ViewModel = App.Current.Services.GetService<MainViewModel>();
        }
    }
}
