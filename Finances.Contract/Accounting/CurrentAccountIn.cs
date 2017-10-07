// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentAccountIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CurrentAccountIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The current account in.
    /// </summary>
    public class CurrentAccountIn : AccountInBase
    {
        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public Guid Bank { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the holder.
        /// </summary>
        public Guid Holder { get; set; }

        /// <summary>
        /// Gets or sets the IBAN.
        /// </summary>
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets the loans.
        /// </summary>
        public List<LoanAccountIn> Loans { get; set; }

        /// <summary>
        /// Gets or sets the savings.
        /// </summary>
        public List<SavingAccountIn> Savings { get; set; }
    }
}