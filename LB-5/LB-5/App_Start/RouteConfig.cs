using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LB_5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "M02V2",
                url: "V2/{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M02" }
            );

            routes.MapRoute(
                name: "M03V3",
                url: "V3/{controller}/{id}/{action}",
                defaults: new { controller = "MResearch", action = "M03", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional }
            );
        }
    }
}
