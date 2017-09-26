// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanOrder.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the HumanOrder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Humans
{
    /// <summary>
    /// The human order.
    /// </summary>
    public class HumanOrder : IListOrder<HumanField>
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public HumanField Field { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is descendent.
        /// </summary>
        public bool IsDesc { get; set; }
    }
}