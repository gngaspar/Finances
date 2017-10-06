// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bank out.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System;

    /// <summary>
    /// The bank out.
    /// </summary>
    public class BankOut : BankIn
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime? ChangeAt { get; set; }
    }
}