using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Banking
{
    public abstract class AccountEntity
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyEntity Currency { get; set; }

        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the the bank.
        /// </summary>
        public BankEntity Bank { get; set; }

        /// <summary>
        /// Gets or sets the Holder name.
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        public bool IsMine { get; set; }

        private DateTime? createdAt;
        public DateTime CreatedAt
        {
            get
            {
                if (createdAt == null)
                {
                    createdAt = DateTime.Now;
                }
                return createdAt.Value;
            }

            set { createdAt = value; }
        }

        /// <summary>
        /// Gets or sets the Change At.
        /// </summary>
        public DateTime? ChangeAt { get; set; }
    }
}
