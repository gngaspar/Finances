namespace Finances.Contract.Banking
{
    public class BankOrder : IListOrder<BankField>
    {
        public BankField Field { get; set; }

        public bool IsDesc { get; set; }
    }
}