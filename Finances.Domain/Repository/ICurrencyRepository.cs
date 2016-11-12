namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    public interface ICurrencyRepository : IDisposable
    {
        Task<CurrencyListResponse> List();
    }
}