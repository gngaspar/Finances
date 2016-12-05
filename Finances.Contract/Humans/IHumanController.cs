namespace Finances.Contract.Humans
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;

    public interface IHumanController
    {
        Task<ActionResponse<HumanListResponse>> List(Guid code, HumanListRequest input);
        
        Task<ActionResponse<Guid>> Add(Guid code, HumanIn input);

        Task<ActionResponse<bool>> Edit(Guid code, Guid human, HumanIn input);
    }
}