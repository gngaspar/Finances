namespace Finances.Client
{
    using System;
    using System.Threading.Tasks;

    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Humans;

    internal class HumanClient : ClientBase, IHumanController
    {
        public HumanClient(IRestSender sender)
            : base(sender)
        {
        }

        public Task<ActionResponse<int>> Add(Guid code, HumanIn input)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<int>> Edit(Guid code, Guid human, HumanIn input)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<HumanListResponse>> List(Guid code, HumanListRequest input)
        {
            throw new NotImplementedException();
        }
    }
}