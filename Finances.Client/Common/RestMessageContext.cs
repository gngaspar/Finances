// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestMessageContext.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the RestMessageContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client.Common
{
    using System.Net.Http;

    /// <summary>
    /// The rest message context.
    /// </summary>
    internal class RestMessageContext : IRestMessageContext
    {
        /// <summary>
        /// Gets or sets the accept.
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the http method.
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Gets or sets the service method.
        /// </summary>
        public ServiceMethod ServiceMethod { get; set; }

        /// <summary>
        /// Gets or sets the url path.
        /// </summary>
        public string UrlPath { get; set; }
    }
}