using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Banking
{
    using Finances.Common.Banking;

    public class Account
    {
        /// <summary>
        /// Gets or sets the Account Type.
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the the bank.
        /// </summary>
        public Bank Bank { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Holder name.
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        public bool IsMine { get; set; }
    }
}