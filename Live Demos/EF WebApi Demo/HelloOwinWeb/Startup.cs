using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartup(typeof(HelloOwinWeb.Startup))]

namespace HelloOwinWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable attribute-based routing
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // Preserve references to avoid cycles in serialization
            config.Formatters.JsonFormatter.SerializerSettings
                .PreserveReferencesHandling = PreserveReferencesHandling.All;

            // Add Web API to the OWIN pipeline
            app.UseWebApi(config);
        }
    }
}
