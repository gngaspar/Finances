namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    public interface ICurrencyRepository : IDisposable
    {
        /// <summary>
        /// Gets the lists the of banks.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The list of Banks</returns>
        Task<CurrencyListResponse> List(CurrencyListRequest parameters);
    }
}