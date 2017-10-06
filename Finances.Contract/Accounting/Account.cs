// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Account.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the Account type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;

    using Finances.Contract.Banking;

    /// <summary>
    /// The account.
    /// </summary>
    public class Account : AccountInBase
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public BankOut Bank { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyOut Currency { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public AccountType Type { get; set; }
    }
}