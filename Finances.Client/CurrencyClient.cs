namespace Finances.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract.Banking;

    public class CurrencyClient : ClientBase, ICurrency
    {
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

        public Task<bool> Update(List<CurrencyIn> input)
        {
            throw new System.NotImplementedException();
        }
    }
}