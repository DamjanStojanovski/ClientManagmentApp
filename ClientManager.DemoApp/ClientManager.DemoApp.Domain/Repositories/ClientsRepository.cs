using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ClientManager.DemoApp.Domain.DataAccess;
using ClientManager.DemoApp.Domain.Models;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;
using Newtonsoft.Json;

namespace ClientManager.DemoApp.Domain.Repositories
{
    public class ClientsRepository : IClientRepository
    {
        private readonly IClientManagmentContext _dbContext;

        public ClientsRepository(IClientManagmentContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IQueryable<Client> GetAllClients()
        {
            return _dbContext.Clients.AsNoTracking();
        }

        public Client GetClientById(int id)
        {

            return _dbContext.Clients.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> GetClientsByName(string name)
        {

            return _dbContext.Clients.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
        }

        public IEnumerable<Client> GetClientsByRegistrationDate(DateTime registrationDate)
        {

            return _dbContext.Clients.Where(c => c.EntryDate == registrationDate);
        }

        public int InsertClient(Client entity)
        {

            bool clientExtis = _dbContext.Clients.Any(x => x.Id == entity.Id);
            if (clientExtis)
            {
                return 0;
            }
            _dbContext.Clients.Add(entity);
            _dbContext.SaveChanges();
            return 1;
        }

        public void UpdateClient(Client entity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveClientById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int ImportClientsFromXMLFile(string xmlFileLocation)
        {
            XDocument document = XDocument.Load(xmlFileLocation);
            var clients = document.Descendants("Client")
                .Select(x => new
                {
                    FirstName = (string)x.Element("FirstName"),
                    LastName = (string)x.Element("LastName"),
                    EntryDate = (DateTime)x.Element("EntryDate"),
                    ClientType = (int)x.Element("ClientType")
                }).ToList();

            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClientManagmentDb;Integrated Security=True");
            connection.Open();
            foreach (var client in clients)
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert INTO Clients (FirstName,LastName, EntryDate, ClientType) VALUES (@firstName,@lastName, @entryDate, @ClientType);";
                    cmd.Parameters.AddWithValue("firstName", client.FirstName);
                    cmd.Parameters.AddWithValue("lastName", client.LastName);
                    cmd.Parameters.AddWithValue("entryDate", client.EntryDate);
                    cmd.Parameters.AddWithValue("ClientType", client.ClientType);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
            }
            connection.Close();

            return 1;
        }

        public void ExportToJSON(string filePath, string name, string dateOfEntry)
        {
            if (File.Exists($"{filePath}\\json.txt"))
            {
                File.Delete($"{filePath}\\json.txt");
            }
            List<Client> clients = new List<Client>();
            bool isDateValid = DateTime.TryParse(dateOfEntry, out DateTime realDate);

            if ((!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name)) && !isDateValid)
            {
                clients = _dbContext.Clients.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name)).ToList();
            }
            else if ((string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) && isDateValid)
            {
                clients = _dbContext.Clients.Where(c => c.EntryDate == realDate).ToList();
            }
            else if ((!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name)) && isDateValid)
            {
                clients = _dbContext.Clients.Where(c => c.EntryDate == realDate && (c.FirstName.Contains(name) || c.LastName.Contains(name))).ToList();
            }
            else
            {
                clients = _dbContext.Clients.ToList();
            }
            string json = JsonConvert.SerializeObject(clients.ToArray());
            File.WriteAllText($"{filePath}\\json.txt", json);
        }
    }
}
