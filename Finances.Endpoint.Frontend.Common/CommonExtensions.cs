// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonExtensions.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The common extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Common
{
    using System.Configuration;
    using System.Web.Routing;

    /// <summary>
    /// The common extensions.
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>
        /// The redirect to process url.
        /// </summary>
        /// <param name="process">
        /// The process.
        /// </param>
        /// <param name="routeData">
        /// The route data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string RedirectToProcessUrl( string process, RouteData routeData )
        {
            var defaultLanguage = ConfigurationManager.AppSettings[ "DefaultLanguage" ];

            if ( string.IsNullOrEmpty( process ) )
            {
                return string.Concat( "~/", defaultLanguage, "/home" );
            }

            var routeValueDictionary = new RouteValueDictionary( routeData.Values );
            if ( routeValueDictionary.ContainsKey( "lang" ) )
            {
                defaultLanguage = (string) routeData.Values[ "lang" ];
            }

            return string.Concat( "~/", defaultLanguage, "/", process );
        }

    }
}
