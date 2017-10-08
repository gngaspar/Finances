// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardListOrder.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CardListOrder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Plastics
{
    /// <summary>
    /// The card list order.
    /// </summary>
    public class CardListOrder : IListOrder<CardField>
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public CardField Field { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is desc.
        /// </summary>
        public bool IsDesc { get; set; }
    }
}
