// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityOwnerBankBase.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Entity even more expanded, to have information about each bank its related
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Entity even more expanded, to have information about each bank its related
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityOwnerBase"/>
    public abstract class EntityOwnerBankBase : EntityOwnerBase
    {
        /// <summary>
        /// Gets or sets the the bank.
        /// </summary>
        /// <value>The bank.</value>
        [Required]
        public Guid Bank { get; set; }
    }
}