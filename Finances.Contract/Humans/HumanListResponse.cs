namespace Finances.Contract.Humans
{
    using System.Collections.Generic;

    /// <summary>
    /// The human list response.
    /// </summary>
    public class HumanListResponse : IListResponse<HumanOut>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<HumanOut> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}