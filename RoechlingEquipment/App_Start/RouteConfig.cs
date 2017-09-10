using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoechlingEquipment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //  name: "Default",
            //  url: "{controller}/{action}/{id}",
            //  defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute(
               name: "LoginPage",
               url: "login.html",
               defaults: new { controller = "Login", action = "LoginPage" });

            routes.MapRoute(
               name: "Default",
               url: "{culture}/index.html",
               defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Home", action = "Index" });
        }
    }
}