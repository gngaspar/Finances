namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    public class BankListResponse : IListResponse<Bank>
    {
        public List<Bank> Banks { get; set; }
        public Bank[] Data { get; set; }
        public int NumberOfItems { get; set; }
    }
}