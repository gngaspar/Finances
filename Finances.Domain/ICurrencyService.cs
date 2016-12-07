namespace Finances.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The Currency service actions methods representantion.
    /// </summary>
    public interface ICurrencyService
    {
        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <returns></returns>
        Task<decimal> Convert(ConvertRequest convert);

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns></returns>
        Task<CurrencyListResponse> List();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Update(List<CurrencyIn> input);
    }
}