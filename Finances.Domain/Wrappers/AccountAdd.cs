// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountAdd.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account add.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Wrappers
{
    using System;

    using Finances.Contract.Accounting;

    /// <summary>
    /// The account add.
    /// </summary>
    public class AccountAdd
    {
        /// <summary>
        /// Gets or sets the current account.
        /// </summary>
        public Guid CurrentAccount { get; set; }

        /// <summary>
        /// Gets or sets the loan.
        /// </summary>
        public LoanAccountIn Loan { get; set; }

        /// <summary>
        /// Gets or sets the saving.
        /// </summary>
        public SavingAccountIn Saving { get; set; }
    }
}
