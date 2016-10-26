namespace Finances.Domain
{
    using System;

    public abstract class EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the last change.
        /// </summary>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}