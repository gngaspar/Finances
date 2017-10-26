namespace Finances.Endpoint.Frontend.Common
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Base area registration class.
    /// .</summary>
    public abstract class BaseAreaRegistration : AreaRegistration
    {
        public override void RegisterArea( AreaRegistrationContext context )
        {
            if ( context == null )
            {
                throw new ArgumentNullException( "context" );
            }

            context.MapRoute(
                string.Concat( this.AreaName, "_Default" ),
                string.Concat( this.AreaName, "/{controller}/{action}/{id}" ),
                new { action = "Index", id = UrlParameter.Optional },
                new[] { string.Concat( "Finances.Endpoint.Frontend.", this.AreaName, ".Controllers" ) } );
        }
    }
}
