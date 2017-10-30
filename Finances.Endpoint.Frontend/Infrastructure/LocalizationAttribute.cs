// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizationAttribute.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the LocalizationAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Infrastructure
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// The localization attribute.
    /// </summary>
    public class LocalizationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The _default language.
        /// </summary>
        private readonly string _defaultLanguage;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationAttribute"/> class.
        /// </summary>
        /// <param name="defaultLanguage">
        /// The default language.
        /// </param>
        public LocalizationAttribute( string defaultLanguage )
        {
            this._defaultLanguage = defaultLanguage;
        }

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            var lang = (string) filterContext.RouteData.Values[ "lang" ] ?? this._defaultLanguage;
            if ( lang == null )
            {
                return;
            }

            try
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo( lang );
            }
            catch ( Exception )
            {
                throw new NotSupportedException( $"Invalid language code '{lang}'." );
            }
        }
    }
}