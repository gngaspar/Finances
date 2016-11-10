namespace Finances.Contract.Banking
{
    public class BankListResponse : IListResponse<BankOut>
    {
        public BankOut[] Data { get; set; }

        public int NumberOfItems { get; set; }
    }
}