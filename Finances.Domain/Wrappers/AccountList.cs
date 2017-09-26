// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountList.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Wrappers
{
    using System;

    using Finances.Contract.Accounting;

    /// <summary>
    /// The account list.
    /// </summary>
    public class AccountList
    {
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        public Guid Owner { get; set; }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        public AccountListRequest Request { get; set; }
    }
}