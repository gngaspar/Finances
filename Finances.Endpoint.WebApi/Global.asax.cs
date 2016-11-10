namespace Finances.Endpoint.WebApi
{
    using System;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}