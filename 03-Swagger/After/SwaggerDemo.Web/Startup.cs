﻿using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SwaggerDemo.Web.Startup))]

namespace SwaggerDemo.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configure Swagger
            SwaggerConfig.Register();

            app.UseWebApi(config);
            //app.UseWelcomePage();
        }
    }
}
