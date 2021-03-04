using Newtonsoft.Json.Serialization;
using Programming.API.Attributes;
using Programming.API.Security;
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
            config.MessageHandlers.Add(new APIKeyHandler());//For Authorization control. This method send "SendAsync();" method in APIKeyHandler.cs for all methods of all controllers but if there no using [Authorize] tags top of methods, this control is not working.

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional } // id parameter is optional.
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;// for Json format Text View line by line send to the client side
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // for Json format Text View properties convert and send camel case format to the client side. 
        }
    }
}
