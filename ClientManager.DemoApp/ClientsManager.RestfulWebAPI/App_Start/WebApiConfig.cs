using ClientsManager.RestfulWebAPI.StartUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ClientsManager.RestfulWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var bootstraper = new Bootstraper();
            bootstraper.Bootstrap();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
        }
    }
}
