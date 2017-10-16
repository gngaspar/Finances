// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizationEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Parameterization representantion on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Projection
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Finances.Contract.Common;

    /// <summary>
    /// The parameterization entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityOwnerBase"/>
    public class ParameterizationEntity : EntityOwnerBase
    {
        /// <summary>
        /// The currency.
        /// </summary>
        private string currency;

        /// <summary>
        /// The cadence.
        /// </summary>
        private string cadence;

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
        /// Gets or sets the cadence.
        /// </summary>
        [NotMapped]
        public Cadence Cadence { get; set; }

        /// <summary>
        /// Gets or sets the cadence string.
        /// </summary>
        [Required]
        [MaxLength( 100 )]
        [Column( "Cadence" )]
        public string CadenceString
        {
            get
            {
                return this.Cadence.ToString();
            }

            set
            {
                this.Cadence = (Cadence) Enum.Parse( typeof( Cadence ), value );
                this.cadence = value;
            }
        }

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