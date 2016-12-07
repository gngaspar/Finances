namespace Finances.DataLayer.Repository
{
    using Finances.Domain.Repository;

    /// <summary>
    /// The account repository.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BankingDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        public AccountRepository()
        {
            this.context = new BankingDbContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">The banking database context.</param>
        internal AccountRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}