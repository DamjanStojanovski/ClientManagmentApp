using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Models;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;
using ClientManager.DemoApp.WPF.Events;
using ClientManager.DemoApp.WPF.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ClientManager.DemoApp.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IClientRepository _clientRepositroy { get; set; }
        private ClientType _selectedClientType;
        private IEventAggregator _eventAgregator;
        private ClientWrapper _newClient;
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<ClientType> ClientTypes
        {
            get
            {
                return Enum.GetValues(typeof(ClientType)).Cast<ClientType>();
            }
        }
        public ClientType SelectedClientType
        {
            get { return _selectedClientType; }
            set
            {
                _selectedClientType = value;
                OnPropertyChanged("SelectedClientType");
            }
        }
        public MainViewModel(IClientRepository clientRepo, IEventAggregator eventAggregator)
        {
            Clients = new ObservableCollection<Client>();
            _eventAgregator = eventAggregator;
            _clientRepositroy = clientRepo;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            NewClient = new ClientWrapper(new Client());
            _eventAgregator.GetEvent<SelectClientEvent>().Subscribe(OnSelectingFriend);
        }
        public ObservableCollection<Client> Clients { get; set; }
        public string Name { get; set; }
        public string DateOfEntry { get; set; }
        public ClientWrapper NewClient
        {
            get
            {
                return _newClient;
            }
            set
            {
                _newClient = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCommand { get; }
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnSelectingFriend(int clientId)
        {
            LoadClientById(clientId);
        }

        public void OnSaveExecute()
        {
            int result = _clientRepositroy.InsertClient(NewClient.Model);
            if (result != 1)
            {
                MessageBox.Show("Something went wrong with saving the user to the database! Try again");
            }
            MessageBox.Show("The user was saved");
        }

        public bool OnSaveCanExecute()
        {
            //TODO: Make logic for save validation
            return true;
        }

        public void LoadAll()
        {
            var clients = _clientRepositroy.GetAllClients();
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }

        public void LoadClientById(int id)
        {
            var client = _clientRepositroy.GetClientById(id);
            NewClient = new ClientWrapper(client);
            NewClient.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(NewClient.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public void ImportFromXml()
        {
            var isImported = _clientRepositroy.ImportClientsFromXMLFile(@"C:\Users\HASELT-Damjan.S\source\repos\ClientManager.DemoApp\ClientManager.DemoApp.WPF\XML\ClientsXML.xml");
            if (isImported == 1)
                MessageBox.Show("Data is imported");
        }

        public void ExportToJSON()
        {
            _clientRepositroy.ExportToJSON(@"C:\Users\HASELT-Damjan.S\source\repos", Name, DateOfEntry);
        }
    }
}
