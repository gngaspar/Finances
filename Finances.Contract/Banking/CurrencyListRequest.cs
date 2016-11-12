namespace Finances.Contract.Banking
{
    public class CurrencyListRequest : IListRequest
    {
        public int ItemsPerPage { get; set; }

        public int Page { get; set; }
    }
}