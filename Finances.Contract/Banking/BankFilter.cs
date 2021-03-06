﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankFilter.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bank filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    /// <summary>
    /// The bank filter.
    /// </summary>
    public class BankFilter
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether name exact.
        /// </summary>
        public bool NameExact { get; set; }

        /// <summary>
        /// Gets or sets the swift.
        /// </summary>
        public string Swift { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether swift exact.
        /// </summary>
        public bool SwiftExact { get; set; }
    }
}