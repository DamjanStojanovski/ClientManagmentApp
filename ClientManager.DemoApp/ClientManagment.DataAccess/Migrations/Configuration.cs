namespace ClientManagment.DataAccess.Migrations
{
    using ClientManager.DemoApp.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientManagment.DataAccess.ClientManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClientManagment.DataAccess.ClientManagementContext context)
        {
            context.Clients.AddOrUpdate(c => c.FirstName,
                 new Client()
                 {
                     FirstName = "Damjan",
                     LastName = "Stojanovski",
                     ClientType = ClientManager.DemoApp.Domain.Enums.ClientType.Standard,
                     EntryDate = DateTime.Now,
                     Addresses = new List<Address>()
                 },
                 new Client()
                 {
                     FirstName = "Ivana",
                     LastName = "Angelovska",
                     ClientType = ClientManager.DemoApp.Domain.Enums.ClientType.Standard,
                     EntryDate = DateTime.Now.AddMonths(-4),
                     Addresses = new List<Address>()
                 },
                 new Client()
                 {
                     FirstName = "Jon",
                     LastName = "Vrencovski",
                     ClientType = ClientManager.DemoApp.Domain.Enums.ClientType.Premium,
                     EntryDate = DateTime.Now.AddMonths(-1),
                     Addresses = new List<Address>()
                 });
        }
    }
}
