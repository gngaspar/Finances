// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountListOrder.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account list order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    /// <summary>
    /// The account list order.
    /// </summary>
    public class AccountListOrder : IListOrder<AccountField>
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public AccountField Field { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is descendent.
        /// </summary>
        public bool IsDesc { get; set; }
    }
}