namespace Finances.Domain.Projection
{
    using System;
    using Finances.Domain.Banking;

    public class ParameterizationEntity : EntityOwnerBase
    {
        public bool Active { get; set; }

        public decimal Amount { get; set; }

        public virtual CurrencyEntity Currency { get; set; }

        public int? Day { get; set; }

        public string Description { get; set; }

        public virtual CurrentAccountEntity FromAccount { get; set; }

        public bool IsMain => Parent == null;

        public ParameterizationEntity Parent { get; set; }

        public DateTime? SpecificDay { get; set; }

        public virtual AccountEntity ToAccount { get; set; }

        public virtual CardEntity ToCard { get; set; }
    }
}