namespace Finances.Contract.Humans
{
    /// <summary>
    /// The human list request.
    /// </summary>
    public class HumanListRequest : IListRequest
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public HumanFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public HumanOrder Order { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }
    }
}