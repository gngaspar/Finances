// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRestMessageContext.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IRestMessageContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client.Common
{
    using System.Net.Http;

    /// <summary>
    /// The RestMessageContext interface.
    /// </summary>
    public interface IRestMessageContext
    {
        /// <summary>
        /// Gets the accept.
        /// </summary>
        string Accept { get; }

        /// <summary>
        /// Gets the content.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the http method.
        /// </summary>
        HttpMethod HttpMethod { get; }

        /// <summary>
        /// Gets the service method.
        /// </summary>
        ServiceMethod ServiceMethod { get; }

        /// <summary>
        /// Gets the url path.
        /// </summary>
        string UrlPath { get; }
    }
}