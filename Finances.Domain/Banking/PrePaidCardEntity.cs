namespace Finances.Domain.Banking
{
    using System.ComponentModel.DataAnnotations;

    public class PrePaidCardEntity : CardEntity
    {
        /// <summary>
        /// Gets or sets the Available Amount.
        /// </summary>
        [Required]
        public decimal AvailableAmount { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Amount.
        /// </summary>
        [Required]
        public decimal MaximumAmount { get; set; }
    }
}