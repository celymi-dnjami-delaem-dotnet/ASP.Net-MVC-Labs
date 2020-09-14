using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LB_3.App_Logic;

namespace LB_3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContactsHandler.ReadFromJsonContacts();
        }
    }
}
