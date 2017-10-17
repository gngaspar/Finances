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
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Parameterizations;
    using Finances.Domain;
    using Finances.Domain.Projection;
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

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Add( Guid owner, ParameterizationIn input )
        {
            var code = Guid.NewGuid();

            var parameterization = new ParameterizationEntity
            {
                Code = code,
                Owner = owner,
                Active = true,
                Parent = null,

                Description = input.Description,
                Cadence = input.Cadence,
                Currency = input.Currency,
                Day = input.Day,
                Amount = input.Amount,
                FromAccount = input.FromAccount,
                ToCard = input.ToCard,
                SpecificDay = input.SpecificDay,
                ToAccount = input.ToAccount
            };


            if ( input.Children != null && input.Children.Count >= 1 )
            {
                var totalAmount = decimal.Zero;

                foreach ( var children in input.Children )
                {
                    var newChildren = new ParameterizationEntity
                    {
                        Code = Guid.NewGuid(),
                        Owner = owner,
                        Parent = code,
                        Active = true,

                        Cadence = input.Cadence,
                        Currency = input.Currency,
                        Day = input.Day,
                        FromAccount = input.FromAccount,
                        SpecificDay = input.SpecificDay,

                        ToAccount = children.ToAccount,
                        ToCard = children.ToCard,
                        Amount = children.Amount,
                        Description = children.Description,
                    };

                    this.context.Parameterizations.Add( newChildren );
                    totalAmount += children.Amount;
                }

                parameterization.Amount = totalAmount;
            }

            this.context.Parameterizations.Add( parameterization );

            var myint = await this.context.SaveChangesAsync();
            return myint;
        }
    }
}
