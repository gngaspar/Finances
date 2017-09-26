// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankOrder.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bank order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    /// <summary>
    /// The bank order.
    /// </summary>
    public class BankOrder : IListOrder<BankField>
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public BankField Field { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is descendent.
        /// </summary>
        public bool IsDesc { get; set; }
    }
}