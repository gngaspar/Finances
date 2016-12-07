using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Gets or sets a value indicating whether is desc.
        /// </summary>
        public bool IsDesc { get; set; }
    }
}
