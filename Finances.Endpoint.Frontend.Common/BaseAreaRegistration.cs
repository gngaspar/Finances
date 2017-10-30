// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseAreaRegistration.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Base area registration class.
//   .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Common
{
    using System;
    using System.Configuration;
    using System.Web.Mvc;

    /// <summary>
    /// Base area registration class.
    /// .</summary>
    public abstract class BaseAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// The register area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public override void RegisterArea( AreaRegistrationContext context )
        {
            if ( context == null )
            {
                throw new ArgumentNullException( "context" );
            }

            context.MapRoute(
                name: string.Concat( this.AreaName, "_Default" ),
                url: string.Concat( "{lang}/", this.AreaName, "/{controller}/{action}/{id}" ),
                defaults: new { lang = ConfigurationManager.AppSettings[ "DefaultLanguage" ], action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = ConfigurationManager.AppSettings[ "PossibleLanguages" ] },
                namespaces: new[] { string.Concat( "Finances.Endpoint.Frontend.", this.AreaName, ".Controllers" ) } );
        }
    }
}
