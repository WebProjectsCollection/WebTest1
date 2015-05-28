using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)

        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Chrome 中浏览网页时会自动请求 favicon.ico，设置此项将其忽略
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute("NotFound", "NotFound.html", new { controller = "Sys", action = "NotFound" });
            routes.MapRoute("Login", "Login.html", new { Controller = "Login", Action = "Index" });
            routes.MapRoute("AutoLogin", "AutoLogin.html", new { Controller = "Login", Action = "Login" });

            routes.MapRoute("do", "{Controller}/{Action}.do");
            routes.MapRoute("html", "{Controller}/{Action}.html");
            //routes.MapRoute("api", "{Controller}/{Action}.api");

            //routes.MapRoute("Default", "Login.html",new { Controller = "Sys", Action = "NotFound" });
            routes.MapRoute(
                name: "Default",
                url: "{Controller}/{Action}",
                defaults: new { controller = "Home", action = "Page" }
            );
        }
    }
}