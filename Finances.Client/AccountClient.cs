namespace Finances.Client
{
    using Finances.Client.Common;
    using Finances.Contract.Accounting;

    public class AccountClient : ClientBase, IAccountController
    {
        public AccountClient(IRestSender sender)
            : base(sender)
        {
        }
    }
}