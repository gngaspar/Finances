using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Endpoint.Frontend.Common
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Routing;

    public abstract class BaseController : Controller
    {
        private string CurrentLanguageCode { get; set; }

        protected override void Initialize( RequestContext requestContext )
        {
            if ( requestContext.RouteData.Values[ "lang" ] != null && requestContext.RouteData.Values[ "lang" ] as string != "null" )
            {
                this.CurrentLanguageCode = (string) requestContext.RouteData.Values[ "lang" ];
                if ( this.CurrentLanguageCode != null )
                {
                    try
                    {
                        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo( this.CurrentLanguageCode );
                    }
                    catch ( Exception )
                    {
                        throw new NotSupportedException( $"Invalid language code '{CurrentLanguageCode}'." );
                    }
                }
            }

            base.Initialize( requestContext );
        }
    }
}
