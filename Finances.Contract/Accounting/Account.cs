namespace Finances.Contract.Accounting
{
    using System;

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