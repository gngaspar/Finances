namespace Finances.Domain.Banking
{
    using System.ComponentModel.DataAnnotations;

    public class CreditCardEntity : CardEntity
    {
        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        [Required]
        public decimal Limit { get; set; }

        /// <summary>
        /// Gets or sets the payment day.
        /// </summary>
        [Required]
        public int PaymentDay { get; set; }

        /// <summary>
        /// Gets or sets the used limit.
        /// </summary>
        [Required]
        public decimal UsedLimit { get; set; }
    }
}