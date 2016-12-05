// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankOrder.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
// Defines the BankOrder type.
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
        /// Gets or sets a value indicating whether is desc.
        /// </summary>
        public bool IsDesc { get; set; }
    }
}