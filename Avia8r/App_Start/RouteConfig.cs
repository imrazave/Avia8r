using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Avia8r
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

         //   //routes.MapRoute(
         //   // name: "Details",
         //   // url: "{controller}/{action}/{AcTail}",
         //   // defaults: new { controller = "Home", action = "Index", AcTail = UrlParameter.Optional }
         //);
        }
    }
}
