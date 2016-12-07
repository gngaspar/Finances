namespace Finances.Contract.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// The account list response.
    /// </summary>
    public class AccountListResponse : IListResponse<AccountItem>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<AccountItem> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}