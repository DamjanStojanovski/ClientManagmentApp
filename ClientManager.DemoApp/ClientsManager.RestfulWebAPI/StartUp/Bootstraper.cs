using Autofac;
using ClientManager.DemoApp.Domain.DataAccess;
using ClientManager.DemoApp.Domain.Repositories;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;

namespace ClientsManager.RestfulWebAPI.StartUp
{
    public class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ClientManagmentContext>().AsSelf();
            builder.RegisterType<ClientsRepository>().As<IClientRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            return builder.Build();
        }
    }
}