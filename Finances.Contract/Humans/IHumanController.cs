namespace Finances.Contract.Humans
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;

    public interface IHumanController
    {
        Task<ActionResponse<HumanListResponse>> List(Guid code, HumanListRequest input);
        
        Task<ActionResponse<int>> Add(Guid code, HumanIn input);

        Task<ActionResponse<int>> Edit(Guid code, Guid human, HumanIn input);
    }
}