// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountDetails.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The current details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Wrappers
{
    using System;

    /// <summary>
    /// The current details.
    /// </summary>
    public class AccountDetails
    {
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        public Guid Owner { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public Guid Code { get; set; }
    }
}