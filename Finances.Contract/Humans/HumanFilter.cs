// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanFilter.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The human filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Humans
{
    /// <summary>
    /// The human filter.
    /// </summary>
    public class HumanFilter
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether email exact.
        /// </summary>
        public bool EmailExact { get; set; }

        /// <summary>
        /// Gets or sets the any name.
        /// </summary>
        public string AnyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether any name exact.
        /// </summary>
        public bool AnyNameExact { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether bring archived.
        /// </summary>
        public bool BringArchived { get; set; }
    }
}