namespace Finances.Contract.Banking
{
    public class BankListRequest : IListRequest
    {
        public BankFilter Filter { get; set; }

        public int ItemsPerPage { get; set; }

        public BankOrder Order { get; set; }

        public int Page { get; set; }
    }
}