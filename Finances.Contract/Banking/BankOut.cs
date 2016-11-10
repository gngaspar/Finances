namespace Finances.Contract.Banking
{
    using System;

    public class BankOut : BankIn
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }
    }
}