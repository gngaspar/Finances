// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoryListRequest.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The history list request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The history list request.
    /// </summary>
    public class HistoryListRequest
    {
        /// <summary>
        /// Gets or sets the currencies.
        /// </summary>
        public List<string> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
