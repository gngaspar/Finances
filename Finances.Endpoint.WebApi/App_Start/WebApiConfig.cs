// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The WebApi Configuration section
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi
{
    using System.Web.Http;

    /// <summary>
    /// The Web API Configuration section
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register( HttpConfiguration config )
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional } );
        }
    }
}