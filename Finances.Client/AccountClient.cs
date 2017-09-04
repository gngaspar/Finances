namespace Finances.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Accounting;

    public class AccountClient : ClientBase, IAccountController
    {
        public AccountClient(IRestSender sender)
            : base(sender)
        {
        }

        public Task<HttpResponseMessage> List( Guid owner, AccountListRequest input )
        {
            throw new NotImplementedException();
        }
    }
}