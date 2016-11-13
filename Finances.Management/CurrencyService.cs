namespace Finances.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;

    /// <summary>
    /// </summary>
    /// <seealso cref="Finances.Domain.ICurrencyService"/>
    public class CurrencyService : ICurrencyService
    {
        /// <summary>
        /// The currency repository
        /// </summary>
        private readonly ICurrencyRepository _currencyRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyService"/> class.
        /// </summary>
        /// <param name="currencyRepository">The currency repository.</param>
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
        }

        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <returns></returns>
        public async Task<decimal> Convert(ConvertRequest convert)
        {
            if (convert == null)
            {
                throw new ArgumentNullException(nameof(convert));
            }

            if (string.IsNullOrEmpty(convert.FromCurrency) || string.IsNullOrEmpty(convert.FromCurrency.Trim()))
            {
                throw new Exception("From currency cant be empty.");
            }

            if (string.IsNullOrEmpty(convert.ToCurrency) || string.IsNullOrEmpty(convert.ToCurrency.Trim()))
            {
                throw new Exception("To currency cant be empty.");
            }

            if (string.Equals(convert.FromCurrency, convert.ToCurrency, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Cant convert to the same currency.");
            }

            if (convert.Amount == 0)
            {
                throw new Exception("Amount must be different of Zero (0).");
            }

            var listOfCurrencies = await this._currencyRepository.List();

            if (listOfCurrencies?.Data == null)
            {
                throw new Exception("Cant get currencies.");
            }

            var from = listOfCurrencies.Data.FirstOrDefault(i => i.CurrencyCode == convert.FromCurrency.ToUpper());
            if (from == null)
            {
                throw new Exception($"Cant find { convert.FromCurrency} currency.");
            }

            var to = listOfCurrencies.Data.FirstOrDefault(i => i.CurrencyCode == convert.ToCurrency.ToUpper());
            if (to == null)
            {
                throw new Exception($"Cant find { convert.ToCurrency} currency.");
            }

            if (from.ReasonToOneEuro == 0 && to.ReasonToOneEuro == 0)
            {
                return convert.Amount;
            }

            if (to.ReasonToOneEuro == 0)
            {
                return convert.Amount / from.ReasonToOneEuro;
            }

            if (from.ReasonToOneEuro == 0)
            {
                return convert.Amount * to.ReasonToOneEuro;
            }

            return to.ReasonToOneEuro * (convert.Amount / from.ReasonToOneEuro);
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns></returns>
        public async Task<CurrencyListResponse> List()
        {
            return await this._currencyRepository.List();
        }

        public async Task<bool> Update(List<CurrencyIn> input)
        {
            return await this._currencyRepository.CopyToHistory();
        }
    }
}