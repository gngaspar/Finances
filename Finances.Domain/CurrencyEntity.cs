namespace Finances.Domain
{
    public class CurrencyEntity : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// Gets or sets the reason to one euro.
        /// </summary>
        public decimal ReasonToOneEuro { get; set; }
    }
}