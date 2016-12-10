using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Accounting
{
    using Finances.Contract.Common;

    public class SavingAccountIn : AccountInBase
    {
        public AutomaticRenovation AutomaticRenovation { get; set; }

        public bool InterestCapitalization { get; set; }

        public InterestPayment InterestPayment { get; set; }

        public DateTime SavingEndDate { get; set; }

        public decimal SavingInterestRate { get; set; }
    }
}
