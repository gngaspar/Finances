namespace Finances.Contract.Banking
{
    using System;
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
        public BankOut BankOut { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

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