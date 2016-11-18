namespace Finances.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The base that allows you to have a unique code and a entity owner.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public abstract class EntityOwnerBase : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>The code.</value>
        [Required]
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <value>The owner.</value>
        [Required]
        public Guid Owner { get; set; }
    }
}