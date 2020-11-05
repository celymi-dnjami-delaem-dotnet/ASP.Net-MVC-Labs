using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;

namespace LB_6
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string RequestType = "Request"; 
        private const string ThreadType = "Thread"; 

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = new StandardKernel();

            var diType = ConfigurationManager.AppSettings["DIType"];
            if (string.Equals(diType, RequestType, StringComparison.OrdinalIgnoreCase))
            {
                kernel.Bind<JSON.DAL.Json.IPhoneDictionary>().To<JSON.DAL.Json.PhoneDictionary>().InRequestScope();
                kernel.Bind<SQL.DAL.Sql.IPhoneDictionary>().To<SQL.DAL.Sql.PhoneDictionary>().InRequestScope().WithConstructorArgument("phoneDictionaryContext", new SQL.DAL.Sql.PhoneDictionaryContext());
            } 
            else if (string.Equals(diType, ThreadType, StringComparison.OrdinalIgnoreCase))
            {
                kernel.Bind<JSON.DAL.Json.IPhoneDictionary>().To<JSON.DAL.Json.PhoneDictionary>().InThreadScope(); 
                kernel.Bind<SQL.DAL.Sql.IPhoneDictionary>().To<SQL.DAL.Sql.PhoneDictionary>().InThreadScope().WithConstructorArgument("phoneDictionaryContext", new SQL.DAL.Sql.PhoneDictionaryContext());
            }

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
