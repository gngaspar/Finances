// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentAccountOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CurrentAccountOut type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;
    using System.Collections.Generic;

    using Finances.Contract.Banking;
    using Finances.Contract.Humans;

    /// <summary>
    /// The current account out.
    /// </summary>
    public class CurrentAccountOut : AccountInBase
    {
        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public BankOut Bank { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyOut Currency { get; set; }

        /// <summary>
        /// Gets or sets the holder.
        /// </summary>
        public HumanOut Holder { get; set; }

        /// <summary>
        /// Gets or sets the IBAN.
        /// </summary>
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets the loans.
        /// </summary>
        public List<LoanAccountOut> Loans { get; set; }

        /// <summary>
        /// Gets or sets the savings.
        /// </summary>
        public List<SavingAccountOut> Savings { get; set; }
    }
}