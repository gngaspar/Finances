// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoanAccountEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The loan account entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Accounting
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Finances.Domain.Extensions;

    /// <summary>
    /// The loan account entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.Accounting.AccountEntity"/>
    public class LoanAccountEntity : AccountEntity
    {
        /// <summary>
        /// Gets or sets the initial amount.
        /// </summary>
        /// <value>The initial amount.</value>
        [Required]
        public decimal InitialAmount { get; set; }

        /// <summary>
        /// Gets or sets the Interest Net Rate.
        /// </summary>
        /// <value>The interest net rate.</value>
        [Required]
        [DecimalPrecision( 18, 3 )]
        public decimal InterestNetRate { get; set; }

        /// <summary>
        /// Gets or sets the Loan end Date.
        /// </summary>
        /// <value>The loan end date.</value>
        [DataType( DataType.Date )]
        public DateTime LoanEndDate { get; set; }

        /// <summary>
        /// Gets or sets the Loan Interest Rate.
        /// </summary>
        /// <value>The loan interest rate.</value>
        [Required]
        [DecimalPrecision( 18, 3 )]
        public decimal LoanInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the Loan related Account.
        /// </summary>
        /// <value>The loan related account.</value>
        public Guid LoanRelatedAccount { get; set; }

        /// <summary>
        /// Gets or sets the Premium Percentage.
        /// </summary>
        /// <value>The premium percentage.</value>
        [Required]
        [DecimalPrecision( 18, 3 )]
        public decimal PremiumPercentage { get; set; }
    }
}