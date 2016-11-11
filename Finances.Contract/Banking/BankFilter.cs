namespace Finances.Contract.Banking
{
    public class BankFilter
    {
        public string Name { get; set; }

        public bool NameExact { get; set; }

        public string Swift { get; set; }

        public bool SwiftExact { get; set; }
    }
}