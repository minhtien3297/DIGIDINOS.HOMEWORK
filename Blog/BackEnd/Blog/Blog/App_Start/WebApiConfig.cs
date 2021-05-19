using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Blog
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("html/text"));

            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}