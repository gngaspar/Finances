namespace Finances.Contract.Banking
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Currency interface
    /// </summary>
    public interface ICurrencyController
    {
        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <returns>the converted amount</returns>
        Task<ActionResponse<decimal>> Convert(ConvertRequest convert);

        /// <summary>
        /// Lists this currencies.
        /// </summary>
        /// <returns>The list of Currencies</returns>
        Task<ActionResponse<CurrencyListResponse>> List();

        /// <summary>
        /// Lists this currencies.
        /// </summary>
        /// <returns>The list of Currencies</returns>
        Task<ActionResponse<int>> Update(List<CurrencyIn> input);
    }
}