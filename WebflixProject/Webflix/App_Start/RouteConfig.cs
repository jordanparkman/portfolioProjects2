using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webflix
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //Custom Route
            /*routes.MapRoute(
                "MoviesByReleaseDate", //route names should be unique
                "movies/released/{year}/{month}", //URL pattern. Parameters get enclosed in curly braces
                new {controller = "Movies", action = "ByReleaseDate" }, //Specify the defaults, using an anonymous object
                new { year = @"2015|2016", month = @"\d{2}" });*/
                

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //The id is passed to the action
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
