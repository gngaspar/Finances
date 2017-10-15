// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizationsRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The parameterizations repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Repository
{
    using Finances.Domain;
    using Finances.Domain.Repository;

    /// <summary>
    /// The parameterizations repository.
    /// </summary>
    public class ParameterizationsRepository : IParameterizationsRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BankingDbContext context;

        /// <summary>
        /// The human repository.
        /// </summary>
        private IHumanRepository humanRepository;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private ICacheProvider cacheProvider;

        /// <summary>
        /// The account repository.
        /// </summary>
        private IAccountRepository accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterizationsRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        /// <param name="humanRepository">
        /// The human Repository.
        /// </param>
        /// <param name="accountRepository">
        /// The account Repository.
        /// </param>
        /// <param name="cacheProvider">
        /// The cache Provider.
        /// </param>
        public ParameterizationsRepository( BankingDbContext bankingDbContext, IHumanRepository humanRepository, IAccountRepository accountRepository, Domain.ICacheProvider cacheProvider )
        {
            this.context = bankingDbContext;
            this.humanRepository = humanRepository;
            this.cacheProvider = cacheProvider;
            this.accountRepository = accountRepository;
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
