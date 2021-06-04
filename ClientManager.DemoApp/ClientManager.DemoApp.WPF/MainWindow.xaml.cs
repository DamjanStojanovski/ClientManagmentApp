using ClientManager.DemoApp.WPF.ViewModels;
using System;
using System.Windows;
using ClientManager.DemoApp.Domain.Models;
using ClientManager.DemoApp.Domain.Enums;
using System.Linq;

namespace ClientManager.DemoApp.WPF
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _mainViewModel.LoadAll();
        }

        private void ImportFromXml(object sender, RoutedEventArgs e)
        {
            _mainViewModel.ImportFromXml();
        }

        private void ExportToJSON(object sender, RoutedEventArgs e)
        {
            _mainViewModel.ExportToJSON();
        }

        private void SaveCustomer(object sender, RoutedEventArgs e)
        {
            _mainViewModel.NewClient.FirstName = FirstName.Text;
            _mainViewModel.NewClient.LastName = LastName.Text;
            _mainViewModel.NewClient.EntryDate = DateTime.Now;
            _mainViewModel.NewClient.ClientType = (ClientType)ClientType.SelectedValue;
        }
    }
}
