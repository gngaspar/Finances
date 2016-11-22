﻿namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    public class CurrencyListResponse : IListResponse<CurrencyOut>
    {
        public List<CurrencyOut> Data { get; set; }

        public int NumberOfItems { get; set; }
    }
}