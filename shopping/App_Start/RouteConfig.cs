using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace shopping
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "SlugDetails",
               url: "{controller}/{action}/{id}/{slug}",
               defaults: new { controller = "Book", action = "Details", id = UrlParameter.Optional,slug=UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "SlugCategory",
              url: "{controller}/{action}/{id}/{slug}",
              defaults: new { controller = "Category", action = "FindCategory", id = UrlParameter.Optional, slug = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
