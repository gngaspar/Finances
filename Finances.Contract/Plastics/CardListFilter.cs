// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardListFilter.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CardListFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Plastics
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The card list filter.
    /// </summary>
    public class CardListFilter
    {
        /// <summary>
        /// Gets or sets the Number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Description exact.
        /// </summary>
        public bool DescriptionExact { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to bring archived.
        /// </summary>
        public bool BringArchived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to bring only my accounts.
        /// </summary>
        public bool BringOnlyMine { get; set; }

        /// <summary>
        /// Gets or sets the Bank.
        /// </summary>
        public Guid Bank { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to filter by bank.
        /// </summary>
        public bool FilterByBank { get; set; }

        /// <summary>
        /// Gets or sets the holder.
        /// </summary>
        public Guid Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to filter by holder.
        /// </summary>
        public bool FilterByHolder { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to filter by currency.
        /// </summary>
        public bool FilterByCurrency { get; set; }

        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        public List<CardType> Types { get; set; }
    }
}
