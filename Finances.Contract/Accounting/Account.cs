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
        /// Gets or sets the type.
        /// </summary>
        public AccountType Type { get; set; }
    }
}