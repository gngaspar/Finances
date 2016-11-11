namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    public class BankListResponse : IListResponse<BankOut>
    {
        public List<BankOut> Data { get; set; }

        public int NumberOfItems { get; set; }
    }
}