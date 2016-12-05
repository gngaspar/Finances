using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain
{
    using Finances.Contract.Humans;

    public interface IHumanService
    {
        Task<Guid> Add(Guid code, HumanIn input);


        Task<bool> Edit(Guid code, Guid human, HumanIn input);

        Task<HumanListResponse> List(Guid code, HumanListRequest input);
    }
}
