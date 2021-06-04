using Autofac;
using ClientManager.DemoApp.WPF.StartUp;
using System.Windows;

namespace ClientManager.DemoApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootsraper = new Bootstraper();
            var container = bootsraper.Bootstrap();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Validation errror happend");
            e.Handled = true;
        }
    }
}
