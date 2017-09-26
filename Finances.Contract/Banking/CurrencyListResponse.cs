// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyListResponse.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The currency list response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    /// <summary>
    /// The currency list response.
    /// </summary>
    public class CurrencyListResponse : IListResponse<CurrencyOut>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<CurrencyOut> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}