// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardListResponse.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CardListResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Plastics
{
    using System.Collections.Generic;

    /// <summary>
    /// The card list response.
    /// </summary>
    public class CardListResponse : IListResponse<Card>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<Card> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}
