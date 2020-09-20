using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace LB_5_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"M01B",
                url: "it/{n}/{stringg}",
                defaults: new { controller = "MResearch", action = "M01B" },
                constraints: new { n = @"\d+", stringg = "[A-Za-z]+" }
                );

            routes.MapRoute(
                name: "M02",
                url: "it/{b}/{letter}",
                defaults: new { controller = "MResearch", action = "M02" },
                constraints: new { b = new BoolRouteConstraint(), letter = new AlphaRouteConstraint() }
            );

            routes.MapRoute(
                name: "M03",
                url: "it/{f}/{stringg}",
                defaults: new { controller = "MResearch", action = "M03" },
                constraints: new { f = new FloatRouteConstraint(), stringg = new LengthRouteConstraint(2, 5) }
            );

            routes.MapRoute(
                name: "M04",
                url: "it/{letters}/{n}/",
                defaults: new { controller = "MResearch", action = "M04" },
                constraints: new { letters = new LengthRouteConstraint(3, 4), n = new RangeRouteConstraint(100, 200) }
            );

            routes.MapRoute(
                name: "M042",
                url: "it/{email}/",
                defaults: new { controller = "MResearch", action = "M04" },
                constraints: new { email = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
