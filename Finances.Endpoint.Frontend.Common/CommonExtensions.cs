using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Endpoint.Frontend.Common
{
    using System.Web.Routing;

    public static class CommonExtensions
    {
        public static string RedirectToProcessUrl( string process, RouteData routeData )
        {
            var defaultLanguage = "en";

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
