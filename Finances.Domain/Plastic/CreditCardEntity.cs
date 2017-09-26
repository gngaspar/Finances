// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreditCardEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Credit Card representantion on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Plastic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The credit card entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.Plastic.CardEntity"/>
    public class CreditCardEntity : CardEntity
    {
        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        [Required]
        public decimal Limit { get; set; }

        /// <summary>
        /// Gets or sets the payment day.
        /// </summary>
        /// <value>The payment day.</value>
        [Required]
        public int PaymentDay { get; set; }

        /// <summary>
        /// Gets or sets the used limit.
        /// </summary>
        /// <value>The used limit.</value>
        [Required]
        public decimal UsedLimit { get; set; }
    }
}