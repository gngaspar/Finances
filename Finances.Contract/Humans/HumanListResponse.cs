using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Humans
{
    public class HumanListResponse : IListResponse<HumanOut>
    {
        public List<HumanOut> Data { get; set; }

        public int NumberOfItems { get; set; }
    }
}
