namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    public class CurrencyListResponse : IListResponse<Currency>
    {
        public List<Currency> Data { get; set; }

        public int NumberOfItems { get; set; }
    }
}