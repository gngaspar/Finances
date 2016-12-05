// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankListRequest.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
// Defines the BankListRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    /// <summary>
    /// The bank list request.
    /// </summary>
    public class BankListRequest : IListRequest
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public BankFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public BankOrder Order { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }
    }
}