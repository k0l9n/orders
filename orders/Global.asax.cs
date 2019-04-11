using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DomainServices;
using DomainServices.Interfaces;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using Repositories;
using StoreDbContext;

namespace orders
{
    public class WebApiApplication : NinjectHttpApplication//HttpApplication //NinjectHttpApplication
    {
        private static StandardKernel _kernel;
        protected override IKernel CreateKernel()
        {
            _kernel = new StandardKernel();

            RegisterServices(_kernel);

            return _kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<StoreDbContext.StoreDbContext>().InRequestScope();
            kernel.Bind<IOrdersService>().To<OrdersService>().InRequestScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            (_kernel.Get<IUnitOfWork>() as StoreDbContext.StoreDbContext)?.Initialize();
        }

        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    GlobalConfiguration.Configure(WebApiConfig.Register);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
    }
}
