using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Contract.Humans
{
    public class HumanListRequest : IListRequest
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public HumanOrder Order { get; set; }

        public int Page { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
