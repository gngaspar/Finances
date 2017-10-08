// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardListRequest.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CardListRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Plastics
{
    /// <summary>
    /// The card list request.
    /// </summary>
    public class CardListRequest : IListRequest
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public CardListFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public CardListOrder Order { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }
    }
}
