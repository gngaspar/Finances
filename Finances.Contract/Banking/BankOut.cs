namespace Finances.Contract.Banking
{
    using System;

    public class BankOut : BankIn
    {
        /// <summary>
        /// Gets or sets the last change.
        /// </summary>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}