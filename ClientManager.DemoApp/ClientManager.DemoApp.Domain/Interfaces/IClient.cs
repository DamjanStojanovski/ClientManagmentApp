using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace ClientManager.DemoApp.Domain.Interfaces
{
    public interface IClient
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime EntryDate { get; set; }
        ICollection<Address> Addresses { get; set; }
        ClientType ClientType { get; set; }
    }
}
