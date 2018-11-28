using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CapstoneFinal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "Actionapi",
                routeTemplate: "api/{controller}/{value}/{id}",
                defaults: new { value = RouteParameter.Optional, id = RouteParameter.Optional }
            );
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new System.Net.Http.Formatting.RequestHeaderMapping("Accept", "text/html",
                    StringComparison.InvariantCultureIgnoreCase, true, "application/json"));

        }
    }
}
