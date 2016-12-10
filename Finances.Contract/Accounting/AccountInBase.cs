using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Accounting
{
    public class AccountInBase
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public Guid Bank { get; set; }

        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the holder.
        /// </summary>
        public Guid Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is archived.
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

    }
}
