// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Card.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the Card type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Plastics
{
    using System;

    using Finances.Contract.Accounting;
    using Finances.Contract.Banking;
    using Finances.Contract.Common;
    using Finances.Contract.Humans;

    /// <summary>
    /// The card.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public SimpleAccount Account { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the expire.
        /// </summary>
        /// <value>The expire.</value>
        public DateTime Expire { get; set; }

        /// <summary>
        /// Gets or sets the Holder object.
        /// </summary>
        /// <value>The holder.</value>
        public HumanOut Holder { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyOut Currency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is archived.
        /// </summary>
        /// <value><c>true</c> if this instance is archived; otherwise, <c>false</c>.</value>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets the card provider.
        /// </summary>
        public CardProvider CardProvider { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public CardType Type { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public BankOut Bank { get; set; }

        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}
