using PocoDemo.Data;
using PocoDemo.Patterns.EF.Repositories;
using PocoDemo.Patterns.EF.UnitOfWork;
using PocoDemo.Patterns.Repositories;
using PocoDemo.Patterns.UnitOfWork;

[assembly: WebActivator.PostApplicationStartMethod(typeof(PocoDemo.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace PocoDemo.Web.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            // Register services
            container.RegisterWebApiRequest<NorthwindSlim>();
            container.RegisterWebApiRequest<IProductsRepository, ProductsRepository>();
            container.RegisterWebApiRequest<ICustomersRepository, CustomersRepository>();
            container.RegisterWebApiRequest<IOrdersRepository, OrdersRepository>();
            container.RegisterWebApiRequest<INorthwindUnitOfWork, NorthwindUnitOfWork>();
        }
    }
}