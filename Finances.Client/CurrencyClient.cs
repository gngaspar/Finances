namespace Finances.Client
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract.Banking;

    public class CurrencyClient : ClientBase, ICurrency
    {
        private const string UrlPrefix = "/Currency/";

        public CurrencyClient(IRestSender sender) : base(sender)
        {
        }

        public Task<decimal> Convert(ConvertRequest convert)
        {
            throw new System.NotImplementedException();
        }

        public Task<CurrencyListResponse> List()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult> Update(List<CurrencyIn> input)
        {
            var context = CreateContextXml();

            context.HttpMethod = HttpMethod.Post;
            context.ServiceMethod = ServiceMethod.Update;
            context.UrlPath = UrlPrefix + "Update";

            return await this.ExecuteSender<List<CurrencyIn>, ActionResult>(input, context);
        }
    }
}