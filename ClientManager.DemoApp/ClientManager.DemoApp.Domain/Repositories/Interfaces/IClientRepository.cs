using ClientManager.DemoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientManager.DemoApp.Domain.Repositories.Interfaces
{
    public interface IClientRepository
    {
        IQueryable<Client> GetAllClients();
        Client GetClientById(int id);
        int InsertClient(Client entity);
        void RemoveClientById(int id);
        void UpdateClient(Client entity);
        IEnumerable<Client> GetClientsByName(string name);
        IEnumerable<Client> GetClientsByRegistrationDate(DateTime registrationDate);
        int ImportClientsFromXMLFile(string xmlFileLocation);
        void ExportToJSON(string filePath, string name, string dateOfEntry);
    }
}
