// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Web API Application Section
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi
{
    using System;
    using System.Web.Http;

    /// <summary>
    /// The Web API Application Section
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication"/>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Application_Start( object sender, EventArgs e )
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure( WebApiConfig.Register );

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;

            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}