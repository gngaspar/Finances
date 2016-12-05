using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Repository
{
    using Finances.Contract.Humans;

    public interface IHumanRepository : IDisposable
    {
        Task<bool> Exist(Guid input);

        Task<bool> ExistOwner(Guid input);

        Task<int> Add(Guid owner, Guid code, HumanIn input);
        
        Task<int> Edit(Guid owner, Guid code, HumanIn input);

        Task<HumanListResponse> List(Guid owner, HumanListRequest input);
    }
}
