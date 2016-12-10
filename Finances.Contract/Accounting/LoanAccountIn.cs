using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Accounting
{
    public class LoanAccountIn : AccountInBase
    {
        public decimal InicialAmount { get; set; }

        public decimal InterestNetRate { get; set; }

        public decimal LoanInterestRate { get; set; }

        public decimal PremiumPercentage { get; set; }

        public DateTime LoanEndDate { get; set; }
    }
}
