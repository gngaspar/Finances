namespace Finances.Domain
{
    using System;

    using Finances.Domain.Banking;
    using Finances.Domain.Human;

    public abstract class EntityOwnerBase : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the CodeName.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        public UserEntity Owner { get; set; }

        /// <summary>
        /// Gets or sets the the bank.
        /// </summary>
        public BankEntity Bank { get; set; }
    }
}