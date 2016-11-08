namespace Finances.Contract.Banking
{
    public class BankListRequest : IListRequest
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}