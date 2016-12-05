namespace Finances.Client
{
    using System;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Banking;

    public class BankClient : ClientBase, IBankController
    {
        public BankClient(IRestSender sender) : base(sender)
        {
        }

        //public Task<BankListResponse> Bankist()
        //{
        //    var context = CreateContextXml();

        // context.HttpMethod = HttpMethod.Post; context.ServiceMethod = ServiceMethod.List;
        // //context.UrlPath = UrlPrefix + string.Format("/{0}/List", userId);

        //    //return await this.ExecuteSender<ListRequest, ListResponse>(request, context);
        //    return new Task<BankListResponse>(new Func<BankListResponse> {Method = { }});
        //}
        public Task<ActionResponse<int>> Add(BankIn bank)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<int>> Edit(Guid code, BankIn bank)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<BankListResponse>> List(BankListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}