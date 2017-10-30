// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend
{
    using System.Web.Mvc;

    using Finances.Endpoint.Frontend.Infrastructure;

    /// <summary>
    /// The filter config.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// The register global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new LocalizationAttribute( "en" ), 0 );
        }
    }
}