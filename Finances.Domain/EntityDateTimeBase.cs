// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityDateTimeBase.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The base of entities to have dates information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;

    /// <summary>
    /// The base of entities to have dates information
    /// </summary>
    public abstract class EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the last change.
        /// </summary>
        /// <value>The change at.</value>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime? CreatedAt { get; set; }
    }
}