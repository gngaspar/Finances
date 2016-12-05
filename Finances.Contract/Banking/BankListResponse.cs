// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankListResponse.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
// Defines the BankListResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    /// <summary>
    /// The bank list response.
    /// </summary>
    public class BankListResponse : IListResponse<BankOut>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<BankOut> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}