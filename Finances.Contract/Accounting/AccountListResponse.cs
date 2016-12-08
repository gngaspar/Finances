namespace Finances.Contract.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// The account list response.
    /// </summary>
    public class AccountListResponse : IListResponse<Account>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<Account> Data { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public int NumberOfItems { get; set; }
    }
}