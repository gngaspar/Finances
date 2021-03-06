﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SavingAccountEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The saving account entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Accounting
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Finances.Contract.Common;
    using Finances.Domain.Extensions;

    /// <summary>
    /// The saving account entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.Accounting.AccountEntity"/>
    public class SavingAccountEntity : AccountEntity
    {
        /// <summary>
        /// The interest payment.
        /// </summary>
        private string interestPayment;

        /// <summary>
        /// The automatic renovation.
        /// </summary>
        private string automaticRenovation;

        /// <summary>
        /// Gets or sets the automatic renovation.
        /// </summary>
        /// <value>The automatic renovation.</value>
        [NotMapped]
        public AutomaticRenovation AutomaticRenovation { get; set; }

        /// <summary>
        /// Gets the automatic renovation string.
        /// </summary>
        /// <value>The automatic renovation string.</value>
        [Required]
        [MaxLength( 100 )]
        [Column( "AutomaticRenovation" )]
        public string AutomaticRenovationString
        {
            get
            {
                return this.AutomaticRenovation.ToString();
            }

            set
            {
                this.AutomaticRenovation = (AutomaticRenovation) Enum.Parse( typeof( AutomaticRenovation ), value );
                this.automaticRenovation = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [interest capitalization].
        /// </summary>
        /// <value><c>true</c> if [interest capitalization]; otherwise, <c>false</c>.</value>
        [Required]
        public bool InterestCapitalization { get; set; }

        /// <summary>
        /// Gets or sets the interest payment.
        /// </summary>
        /// <value>The interest payment.</value>
        [NotMapped]
        public Cadence InterestPayment { get; set; }

        /// <summary>
        /// Gets the interest payment string.
        /// </summary>
        /// <value>The interest payment string.</value>
        [Required]
        [MaxLength( 100 )]
        [Column( "InterestPayment" )]
        public string InterestPaymentString
        {
            get
            {
                return this.InterestPayment.ToString();
            }

            set
            {
                this.InterestPayment = (Cadence) Enum.Parse( typeof( Cadence ), value );
                this.interestPayment = value;
            }
        }

        /// <summary>
        /// Gets or sets the saving end date.
        /// </summary>
        /// <value>The saving end date.</value>
        [Required]
        [DataType( DataType.Date )]
        public DateTime SavingEndDate { get; set; }

        /// <summary>
        /// Gets or sets the saving interest rate.
        /// </summary>
        /// <value>The saving interest rate.</value>
        [Required]
        [DecimalPrecision( 18, 3 )]
        public decimal SavingInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the saving related account.
        /// </summary>
        /// <value>The saving related account.</value>
        public Guid SavingRelatedAccount { get; set; }
    }
}