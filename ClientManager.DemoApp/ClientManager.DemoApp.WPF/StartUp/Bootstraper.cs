using Autofac;
using ClientManager.DemoApp.Domain.DataAccess;
using ClientManager.DemoApp.Domain.Repositories;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;
using ClientManager.DemoApp.WPF.ViewModels;
using Prism.Events;

namespace ClientManager.DemoApp.WPF.StartUp
{
    public class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<ClientManagmentContext>().As<IClientManagmentContext>();
            builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<ClientsRepository>().As<IClientRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            return builder.Build();
        }
    }
}
