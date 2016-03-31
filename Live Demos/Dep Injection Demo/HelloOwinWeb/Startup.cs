using System.Web.Http;
using Microsoft.Owin;
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

            // Configure ID
            SimpleInjectorWebApiInitializer.Initialize(config);

            // Add Web API to the OWIN pipeline
            app.UseWebApi(config);
        }
    }
}
