// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRestResult.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IRestResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client.Common
{
    /// <summary>
    /// The RestResult interface.
    /// </summary>
    public interface IRestResult
    {
        /// <summary>
        /// Gets the content.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the http status.
        /// </summary>
        int HttpStatus { get; }
    }
}