using System.Web.Http;
using HelloOwinWeb;
using RepoUoW.Patterns;
using RepoUoW.Patterns.EF;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

//[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorWebApiInitializer), "Initialize")]

namespace HelloOwinWeb
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(config);
       
            container.Verify();
            
            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
            container.Register<Northwind>(Lifestyle.Scoped);
        }
    }
}