// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageHelper.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the LanguageHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Infrastructure
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The language helper.
    /// </summary>
    public static class LanguageHelper
    {
        /// <summary>
        /// The lang switcher.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="Name">
        /// The name.
        /// </param>
        /// <param name="routeData">
        /// The route data.
        /// </param>
        /// <param name="lang">
        /// The lang.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString LangSwitcher( this UrlHelper url, string Name, RouteData routeData, string lang )
        {
            var liTagBuilder = new TagBuilder( "li" );
            var aTagBuilder = new TagBuilder( "a" );
            var routeValueDictionary = new RouteValueDictionary( routeData.Values );
            if ( routeValueDictionary.ContainsKey( "lang" ) )
            {
                if ( routeData.Values[ "lang" ] as string == lang )
                {
                    liTagBuilder.AddCssClass( "active" );
                }
                else
                {
                    routeValueDictionary[ "lang" ] = lang;
                }
            }

            aTagBuilder.MergeAttribute( "href", url.RouteUrl( routeValueDictionary ) );
            aTagBuilder.SetInnerText( Name );
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString( liTagBuilder.ToString() );
        }
    }
}