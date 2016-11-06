namespace Finances.Domain.Banking
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Finances.Domain.Extensions;

    public class LoanAccountEntity : AccountEntity
    {
        [Required]
        public decimal InicialAmount { get; set; }

        [Required]
        [DecimalPrecision(18, 3)]
        public decimal InterestNetRate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoanEndDate { get; set; }

        [Required]
        [DecimalPrecision(18, 3)]
        public decimal LoanInterestRate { get; set; }

        public virtual CurrentAccountEntity LoanRelatedAccount { get; set; }

        [Required]
        [DecimalPrecision(18, 3)]
        public decimal PremiumPercentage { get; set; }
    }
}