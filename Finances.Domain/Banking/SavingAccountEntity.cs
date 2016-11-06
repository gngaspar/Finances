namespace Finances.Domain.Banking
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Finances.Common.Banking;
    using Finances.Domain.Extensions;

    public class SavingAccountEntity : AccountEntity
    {
        [NotMapped]
        public AutomaticRenovation AutomaticRenovation { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("AutomaticRenovation")]
        public string AutomaticRenovationString => AutomaticRenovation.ToString();

        [Required]
        public bool InterestCapitalization { get; set; }

        [NotMapped]
        public InterestPayment InterestPayment { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("InterestPayment")]
        public string InterestPaymentString => InterestPayment.ToString();

        [Required]
        [DataType(DataType.Date)]
        public DateTime SavingEndDate { get; set; }

        [Required]
        [DecimalPrecision(18, 3)]
        public decimal SavingInterestRate { get; set; }

        public virtual CurrentAccountEntity SavingRelatedAccount { get; set; }
    }
}