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
               url: "sach/chi-tiet/{slug}-{id}",
               defaults: new { controller = "Book", action = "Details", id = UrlParameter.Optional,slug=UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "SlugCategory",
              url: "sach/the-loai/{slug}-{id}",
              defaults: new { controller = "Category", action = "FindCategory", id = UrlParameter.Optional, slug = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "SlugCategoryParent",
              url: "sach/danh-muc/{slug}-{id}",
              defaults: new { controller = "Category", action = "FindCategoryParent", id = UrlParameter.Optional, slug = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "SlugPublisher",
              url: "sach/nha-xuat-ban/{slug}-{id}",
              defaults: new { controller = "Publisher", action = "FindPublisher", id = UrlParameter.Optional, slug = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "SlugCartitem",
              url: "chi-tiet-gio-hang",
              defaults: new { controller = "CartItem", action = "Cart"}
            );

            routes.MapRoute(
             name: "SlugEditCartitem",
             url: "cap-nhat-gio-hang",
             defaults: new { controller = "CartItem", action = "EditCartitem" }
           );

            routes.MapRoute(
                 name: "SlugDeleteCartitem",
                 url: "xoa-gio-hang/{slug}-{id}",
                 defaults: new { controller = "CartItem", action = "DeleteCartitem" ,slug=UrlParameter.Optional,id=UrlParameter.Optional}
                );

            routes.MapRoute(
                 name: "SearchBook",
                 url: "sach/tim-kiem/{f}",
                 defaults: new { controller = "Book", action = "SearchBook", f = UrlParameter.Optional }
                );
            routes.MapRoute(
              name: "BookEdit",
              url: "admin/sach/chinh-sua/{slug}-{id}",
              defaults: new { controller = "Book", action = "Edit", id = UrlParameter.Optional, slug = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Register",
            url: "dang-ky",
            defaults: new { controller = "Accounts", action = "Create"}
          );
            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",
            defaults: new { controller = "Home", action = "login" }
          );
            routes.MapRoute(
                name: "Loutout",
                url: "dang-xuat",
                defaults: new { controller = "Home", action = "logout" }
                );
            routes.MapRoute(
                name: "EditAccount",
                url: "chinh-sua-thong-tin-{id}",
                defaults: new { controller = "Accounts", action = "Edit",id=UrlParameter.Optional }
          );
            routes.MapRoute(
                name:"Administrator",
                url:"trang-quan-tri",
                defaults:new {controller="Admin",action="Index"}
                );
            routes.MapRoute(
               name: "LogOrder",
               url: "lich-su-mua-hang",
               defaults: new { controller = "Accounts", action = "LogOrder" }
               );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
