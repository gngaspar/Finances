// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestResult.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the RestResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client.Common
{
    /// <summary>
    /// The rest result.
    /// </summary>
    public class RestResult : IRestResult
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the http status.
        /// </summary>
        public int HttpStatus { get; set; }
    }
}