namespace Finances.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
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
        [Required]
        public virtual PersonEntity Owner { get; set; }
    }
}