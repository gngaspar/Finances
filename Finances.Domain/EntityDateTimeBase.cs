using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain
{
    public abstract class EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the Created At.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the Change At.
        /// </summary>
        public DateTime ChangeAt { get; set; }
    }
}
