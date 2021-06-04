using ClientManager.DemoApp.Domain.DataAccess;
using ClientManager.DemoApp.Domain.Repositories;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ClientManagmert.RestfulAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IClientManagmentContext, ClientManagmentContext>();
            container.RegisterType<IClientRepository, ClientsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}