using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Contract.Banking;

namespace Finances.Domain.Banking
{
    public class BankEntity : Bank
    {
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
