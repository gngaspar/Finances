using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Banking
{
    public class LoanAccountEntity : AccountEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
