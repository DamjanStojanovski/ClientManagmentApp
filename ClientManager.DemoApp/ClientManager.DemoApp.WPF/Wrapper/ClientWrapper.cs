using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClientManager.DemoApp.WPF.Wrapper
{
    public class ClientWrapper: INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public ClientWrapper(Client client)
        {
            Model = client;
        }

        public Client Model { get;}
        public int Id { get { return Model.Id; }}
        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
                OnPropertyChanged();
                ValidateProperty(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
                OnPropertyChanged();
                ValidateProperty(nameof(LastName));
            }
        }

        public DateTime EntryDate
        {
            get
            {
                return Model.EntryDate;
            }
            set
            {
                Model.EntryDate = value;
                OnPropertyChanged();
            }
        }

        public ClientType ClientType
        {
            get
            {
                return Model.ClientType;
            }
            set
            {
                Model.ClientType = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<string, List<string>> _propertyErrors =
            new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyErrors.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.ContainsKey(propertyName) ? _propertyErrors[propertyName] : null;
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddErrorToProperty(string propertyName, string error)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
                _propertyErrors[propertyName] = new List<string>();

            if (!_propertyErrors[propertyName].Contains(error))
            {
                _propertyErrors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            bool firstNameHasNumber = false;
            bool lastNameHasNumber = false;

            if (FirstName == null)
                FirstName = string.Empty;

            if (LastName == null)
                LastName = string.Empty;

            foreach (var character in FirstName)
            {
                if (Char.IsDigit(character))
                    firstNameHasNumber = true;
            }

            foreach (var character in LastName)
            {
                if (Char.IsDigit(character))
                    lastNameHasNumber = true;
            }
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, string.Empty, StringComparison.OrdinalIgnoreCase))
                    {
                        AddErrorToProperty(propertyName, "You can not have empty string as first name");
                    }
                    if (FirstName.Length < 3)
                    {
                        AddErrorToProperty(propertyName, "First name must be longer then 3 characters");
                    }
                    if (firstNameHasNumber)
                    {
                        AddErrorToProperty(propertyName, "You can not have digits in the first name");
                    }
                    break;
                case nameof(LastName):
                    if (string.Equals(LastName, string.Empty, StringComparison.OrdinalIgnoreCase))
                    {
                        AddErrorToProperty(propertyName, "You can not have empty string as last name");
                    }
                    if (LastName.Length < 3)
                    {
                        AddErrorToProperty(propertyName, "Last name must be longer then 3 characters");
                    }
                    if (lastNameHasNumber)
                    {
                        AddErrorToProperty(propertyName, "You can not have digits in the last name");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
