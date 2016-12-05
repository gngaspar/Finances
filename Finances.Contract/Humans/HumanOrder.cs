using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Humans
{
    public class HumanOrder : IListOrder<HumanField>
    {
        public HumanField Field { get; set; }

        public bool IsDesc { get; set; }
    }
}
