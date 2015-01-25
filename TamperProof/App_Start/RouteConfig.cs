using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using TamperProof.Infrastructure;

namespace TamperProof
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var customRoute = new CryptoRoute("{controller}/{action}/{id}",
                new RouteValueDictionary( new { controller = "Home", action = "Index", id = UrlParameter.Optional } ),
                new MvcRouteHandler());

            routes.Add("Default", customRoute);
        }

    }
}
