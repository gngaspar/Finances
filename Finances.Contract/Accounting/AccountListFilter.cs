namespace Finances.Contract.Accounting
{
    /// <summary>
    /// The account list filter.
    /// </summary>
    public class AccountListFilter
    {
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Description exact.
        /// </summary>
        public bool DescriptionExact { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to bring archived.
        /// </summary>
        public bool BringArchived { get; set; }
    }
}