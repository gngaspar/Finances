// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The human in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Humans
{
    using System;

    /// <summary>
    /// The human in.
    /// </summary>
    public class HumanIn
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is archived.
        /// </summary>
        public bool IsArchived { get; set; }
    }
}