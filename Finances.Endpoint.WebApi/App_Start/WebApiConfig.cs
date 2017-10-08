// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The WebApi Configuration section
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi
{
    using System.Web.Http;

    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The Web API Configuration section
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register( HttpConfiguration config )
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Converters.Add( new Newtonsoft.Json.Converters.StringEnumConverter() );
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove( config.Formatters.XmlFormatter );
        }
    }
}