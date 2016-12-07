using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Accounting
{
    public class AccountItem
    {
        public Guid Code { get; set; }

        public string Description { get; set; }

        public DateTime? ChangeAt { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
