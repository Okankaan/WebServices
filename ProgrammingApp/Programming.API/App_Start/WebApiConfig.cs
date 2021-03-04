using Programming.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Programming.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttributes());// For using OnException() method in ApiExceptionAttributes.cs. We use here for at the level of Application using(Alternatively, We can use this tags top of all method of all controllers one by one).

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional } // id parameter is optional.
            );
        }
    }
}
