namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System.Web.Http;

    using Finances.Contract.Accounting;

    public class AccountController : ApiController, IAccountController
    {
    }
}