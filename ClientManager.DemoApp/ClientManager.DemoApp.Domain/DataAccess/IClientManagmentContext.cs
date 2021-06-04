using ClientManager.DemoApp.Domain.Models;
using System.Data.Entity;

namespace ClientManager.DemoApp.Domain.DataAccess
{
    public interface IClientManagmentContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Address> Addresses { get; set; }
        void SaveChanges();
    }
}
