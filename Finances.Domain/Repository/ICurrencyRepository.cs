namespace Finances.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    public interface ICurrencyRepository : IDisposable
    {
        Task<int> CopyToHistory();

        Task<DateTime> GetTheHistoryLastDay();

        Task<CurrencyListResponse> List();

        Task<int> Update(List<CurrencyIn> input);
    }
}