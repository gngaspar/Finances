namespace Finances.Domain.Plastic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Pre paid Card representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.Plastic.CardEntity"/>
    public class PrePaidCardEntity : CardEntity
    {
        /// <summary>
        /// Gets or sets the Available Amount.
        /// </summary>
        /// <value>The available amount.</value>
        [Required]
        public decimal AvailableAmount { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Amount.
        /// </summary>
        /// <value>The maximum amount.</value>
        [Required]
        public decimal MaximumAmount { get; set; }
    }
}