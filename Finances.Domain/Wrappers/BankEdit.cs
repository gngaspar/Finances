namespace Finances.Domain.Wrappers
{
    using System;
    using Finances.Contract.Banking;

    /// <summary>
    /// The bank edit.
    /// </summary>
    public class BankEdit
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public BankIn Bank { get; set; }
    }
}