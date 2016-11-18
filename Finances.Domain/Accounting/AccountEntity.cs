namespace Finances.Domain.Accounting
{
    using System;

    /// <summary>
    /// The Account representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityOwnerBankBase"/>
    public abstract class AccountEntity : EntityOwnerBankBase
    {
        private string _currency;

        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Currency
        {
            get { return _currency.ToUpper(); }
            set { _currency = value.ToUpper(); }
        }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Holder object.
        /// </summary>
        /// <value>The holder.</value>
        public virtual Guid Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        /// <value><c>true</c> if this instance is mine; otherwise, <c>false</c>.</value>
        public bool IsMine => this.Holder == this.Owner;

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the Starting Date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; set; }
    }
}