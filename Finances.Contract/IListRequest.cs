// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IListRequest.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Request interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract
{
    /// <summary>
    /// The Request interface.
    /// </summary>
    public interface IListRequest
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        int ItemsPerPage { get; set; }
    }
}