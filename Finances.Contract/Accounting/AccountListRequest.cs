// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountListRequest.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account list request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    /// <summary>
    /// The account list request.
    /// </summary>
    public class AccountListRequest : IListRequest
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public AccountListFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public AccountListOrder Order { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }
    }
}