// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubParameterizationIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the SubParameterizationIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Parameterizations
{
    using System;

    /// <summary>
    /// The sub parameterization in.
    /// </summary>
    public class SubParameterizationIn
    {
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }
    }
}
