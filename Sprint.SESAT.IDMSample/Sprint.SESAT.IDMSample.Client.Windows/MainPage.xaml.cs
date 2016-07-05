using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;

namespace Sprint.SESAT.IDMSample.Client.Windows
{
    public sealed partial class MainPage : Page
    {
        private SampleViewModel ViewModel => DataContext as SampleViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadDataCommand.Execute(null);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.LogoutCommand.Execute(null);
        }

        private void Logout_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadDataCommand.Execute(null);
        }
    }
}
