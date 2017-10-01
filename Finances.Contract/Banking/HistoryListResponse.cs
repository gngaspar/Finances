// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoryListResponse.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The history list response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    /// <summary>
    /// The history list response.
    /// </summary>
    public class HistoryListResponse : IListResponse<HistoryOut>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<HistoryOut> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}
