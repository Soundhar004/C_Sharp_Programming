using System.Web.Http;

namespace Coding_Challenge_10_Q1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            // Optional: Default route fallback (if attribute routing is not used)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Optional: Format JSON responses with camelCase
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            // Optional: Remove XML formatter if you only want JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
