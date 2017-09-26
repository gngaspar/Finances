// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Person representantion on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Human
{
    using System;

    /// <summary>
    /// The person entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public class PersonEntity : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>The code.</value>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is archived.
        /// </summary>
        /// <value><c>true</c> if this instance is archived; otherwise, <c>false</c>.</value>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the user it self.
        /// </summary>
        /// <value><c>true</c> if this instance is me; otherwise, <c>false</c>.</value>
        public bool IsMe => this.Code == this.OwnerCode;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CodeName.
        /// </summary>
        /// <value>The owner code.</value>
        public Guid OwnerCode { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }
    }
}