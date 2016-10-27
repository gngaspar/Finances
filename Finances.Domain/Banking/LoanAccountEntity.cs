namespace Finances.Domain.Banking
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LoanAccountEntity : AccountEntity
    {
        [Required]
        public decimal InicialAmount { get; set; }

        [Required]
        public decimal InterestNetRate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoanEndDate { get; set; }

        [Required]
        public decimal LoanInterestRate { get; set; }

        public virtual CurrentAccountEntity LoanRelatedAccount { get; set; }

        [Required]
        public decimal PremiumPercentage { get; set; }
    }
}