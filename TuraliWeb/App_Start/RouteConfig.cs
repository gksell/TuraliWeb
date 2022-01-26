using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TuraliWeb
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

            routes.MapRoute(
                name:"Category2List",
                url: "{controller}/{categoryname}/{action}/{id}"

                );
            routes.MapRoute(
               name: "Category3List",
               url: "{controller}/{categoryname}/{categoryname1}/{action}/{id}"

                );
            routes.MapRoute(
               name: "Products",
               url: "{controller}/{categoryname}/{categoryname1}/{categoryname2}/{action}/{id}"

                );
        }
    }
}
