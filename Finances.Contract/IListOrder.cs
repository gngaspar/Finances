// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IListOrder.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The ListOrder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract
{
    /// <summary>
    /// The ListOrder interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type of field order.
    /// </typeparam>
    public interface IListOrder<T>
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        T Field { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is descendent.
        /// </summary>
        bool IsDesc { get; set; }
    }
}