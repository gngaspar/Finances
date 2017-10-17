// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizationIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the ParameterizationIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Parameterizations
{
    using System;
    using System.Collections.Generic;
    using Finances.Contract.Common;

    /// <summary>
    /// The parameterization in.
    /// </summary>
    public class ParameterizationIn
    {
        /// <summary>
        /// The currency.
        /// </summary>
        private string currency;

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
            get { return this.currency.ToUpper(); }
            set { this.currency = value.ToUpper(); }
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
        /// Gets or sets the specific day.
        /// </summary>
        /// <value>The specific day.</value>
        public DateTime? SpecificDay { get; set; }

        /// <summary>
        /// Gets or sets the cadence.
        /// </summary>
        public Cadence Cadence { get; set; }

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

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public List<SubParameterizationIn> Children { get; set; }
    }
}
