using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Accounting
{
    public class CurrentAccountOut : AccountInBase
    {
        public string Iban { get; set; }

        public List<LoanAccountOut> Loans { get; set; }

        public List<SavingAccountOut> Savings { get; set; }
    }
}
