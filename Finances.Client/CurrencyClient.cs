namespace Finances.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Banking;

    public class CurrencyClient : ClientBase, ICurrencyController
    {
        private const string UrlPrefix = "/Currency/";

        public CurrencyClient(IRestSender sender) : base(sender)
        {
        }

        ////public Task<decimal> Convert(ConvertRequest convert)
        ////{
        ////    throw new System.NotImplementedException();
        ////}

        ////public Task<CurrencyListResponse> List()
        ////{
        ////    throw new System.NotImplementedException();
        ////}

        ////public async Task<ActionResponse> Update(List<CurrencyIn> input)
        ////{
        ////    var context = CreateContextXml();

        ////    context.HttpMethod = HttpMethod.Post;
        ////    context.ServiceMethod = ServiceMethod.Update;
        ////    context.UrlPath = UrlPrefix + "Update";

        ////    return await this.ExecuteSender<List<CurrencyIn>, ActionResponse>(input, context);
        ////}

        public Task<HttpResponseMessage> Convert(ConvertRequest convert)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ConvertString(string toCurrency, string fromCurrency, decimal amount)
        {
            throw new NotImplementedException();
        }

        Task<HttpResponseMessage> ICurrencyController.List()
        {
            throw new NotImplementedException();
        }

        Task<ActionResponse<int>> ICurrencyController.Update(List<CurrencyIn> input)
        {
            throw new NotImplementedException();
        }
    }
}