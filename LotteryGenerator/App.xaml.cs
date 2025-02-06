using System.Windows;

namespace LotteryGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var view = new MainWindow();
            var viewModel = new MainWindowViewModel();
            view.DataContext = viewModel;

            view.ShowDialog();
        }
    }

}
