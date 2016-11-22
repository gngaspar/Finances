namespace Finances.Domain.Projection
{
    using System;

    /// <summary>
    /// The Parameterization representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityOwnerBase"/>
    public class ParameterizationEntity : EntityOwnerBase
    {
        private string _currency;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ParameterizationEntity"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Currency
        {
            get { return this._currency.ToUpper(); }
            set { this._currency = value.ToUpper(); }
        }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public int? Day { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets from account.
        /// </summary>
        /// <value>From account.</value>
        public Guid? FromAccount { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is main.
        /// </summary>
        /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        public bool IsMain => this.Parent == null;

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public Guid? Parent { get; set; }

        /// <summary>
        /// Gets or sets the specific day.
        /// </summary>
        /// <value>The specific day.</value>
        public DateTime? SpecificDay { get; set; }

        /// <summary>
        /// Gets or sets to account.
        /// </summary>
        /// <value>To account.</value>
        public Guid? ToAccount { get; set; }

        /// <summary>
        /// Gets or sets to card.
        /// </summary>
        /// <value>To card.</value>
        public Guid? ToCard { get; set; }
    }
}