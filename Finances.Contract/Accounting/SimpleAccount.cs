// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleAccount.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The simple account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;

    /// <summary>
    /// The simple account.
    /// </summary>
    public class SimpleAccount
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public AccountType Type { get; set; }
    }
}
