// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the RouteConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The route config.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The register routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                name: "Language",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = "en", controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"en|pt|pl" },
                namespaces: new[] { "Finances.Endpoint.Frontend.Controllers" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { lang = "en", controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "Finances.Endpoint.Frontend.Controllers" } );
        }
    }
}
