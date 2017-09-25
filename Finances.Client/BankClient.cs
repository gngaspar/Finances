namespace Finances.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Banking;

    public class BankClient : ClientBase, IBankController
    {
        public BankClient(IRestSender sender) : base(sender)
        {
        }

        ////public Task<BankListResponse> Bankist()
        ////{
        ////    var context = CreateContextXml();

        //// context.HttpMethod = HttpMethod.Post; context.ServiceMethod = ServiceMethod.List;
        //// //context.UrlPath = UrlPrefix + string.Format("/{0}/List", userId);

        ////    //return await this.ExecuteSender<ListRequest, ListResponse>(request, context);
        ////    return new Task<BankListResponse>(new Func<BankListResponse> {Method = { }});
        
        public Task<HttpResponseMessage> Add(BankIn bank)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<bool>> Edit(Guid code, BankIn bank)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> List(BankListRequest input)
        {
            throw new NotImplementedException();
        }
    }
}