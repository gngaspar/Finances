namespace Finances.Domain.Banking
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LoanAccountEntity : AccountEntity
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal InterestRate { get; set; }
    }
}