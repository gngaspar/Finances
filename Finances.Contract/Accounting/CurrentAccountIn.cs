using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Accounting
{
    public class CurrentAccountIn : AccountInBase
    {
        public string Iban { get; set; }


        public List<LoanAccountIn> Loans { get; set; }

        public List<SavingAccountIn> Savings { get; set; }

    }
}
