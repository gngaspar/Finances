// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Management
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The account service.
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IAccountRepository accountRepository;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private ICacheProvider cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountRepository">
        /// The repository.
        /// </param>
        public AccountService( IAccountRepository accountRepository, ICacheProvider cacheProvider )
        {
            this.accountRepository = accountRepository;
            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        public async Task<AccountListResponse> List( AccountList input )
        {
            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            if ( input.Request == null )
            {
                throw new ArgumentNullException( nameof( input.Request ) );
            }

            if ( input.Owner == null || Guid.Empty == input.Owner )
            {
                throw new ArgumentNullException( nameof( input.Owner ) );
            }

            // TODO: Add validations
            return await this.accountRepository.List( input.Owner, input.Request );
        }

        /// <summary>
        /// The add current account.
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
        /// <exception cref="ArgumentNullException">
        /// The Argument Null Exception.
        /// </exception>
        public async Task<Guid> AddCurrentAccount( Guid owner, CurrentAccountIn input )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( nameof( owner ) );
            }

            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            // TODO: Add validations
            if ( !this.cacheProvider.Banks.Select( x => x.Code ).Contains( input.Bank ) )
            {
                throw new Exception( "The Bank " + input.Bank + " doesnt look valid." );
            }

            if ( !this.cacheProvider.Currencies.Select( x => x.Code ).Contains( input.Currency ) )
            {
                throw new Exception( "The currency " + input.Currency + " doesnt look valid." );
            }

            var currentGuid = Guid.NewGuid();

            var result = await this.accountRepository.Add( owner, currentGuid, input );

            return result != 0 ? currentGuid : Guid.Empty;
        }

        /// <summary>
        /// The add saving account.
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
        public async Task<Guid> AddSavingAccount( Guid owner, AccountAdd input )
        {
            var id = Guid.NewGuid();
            if ( !this.cacheProvider.Banks.Select( x => x.Code ).Contains( input.Saving.Bank ) )
            {
                throw new Exception( "The Bank " + input.Saving.Bank + " doesnt look valid." );
            }

            if ( !this.cacheProvider.Currencies.Select( x => x.Code ).Contains( input.Saving.Currency ) )
            {
                throw new Exception( "The currency " + input.Saving.Currency + " doesnt look valid." );
            }

            var done = await this.accountRepository.Add( owner, input.CurrentAccount, id, input.Saving );
            if ( done == 1 )
            {
                return id;
            }

            return Guid.Empty;
        }

        /// <summary>
        /// The add loan account.
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
        public async Task<Guid> AddLoanAccount( Guid owner, AccountAdd input )
        {
            var id = Guid.NewGuid();
            if ( !this.cacheProvider.Banks.Select( x => x.Code ).Contains( input.Loan.Bank ) )
            {
                throw new Exception( "The Bank " + input.Loan.Bank + " doesnt look valid." );
            }

            if ( !this.cacheProvider.Currencies.Select( x => x.Code ).Contains( input.Loan.Currency ) )
            {
                throw new Exception( "The currency " + input.Loan.Currency + " doesnt look valid." );
            }

            var done = await this.accountRepository.Add( owner, input.CurrentAccount, id, input.Loan );
            if ( done == 1 )
            {
                return id;
            }

            return Guid.Empty;
        }

        /// <summary>
        /// The get loan details.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<LoanAccountOut> GetLoanDetails( AccountDetails input )
        {
            await this.Validate( input );

            var details = await this.accountRepository.GetLoan( input.Code );

            if ( details == null )
            {
                throw new Exception( "Account " + input.Code + " couldnt be found." );
            }

            return details;
        }

        /// <summary>
        /// The get saving details.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<SavingAccountOut> GetSavingDetails( AccountDetails input )
        {
            await this.Validate( input );

            var details = await this.accountRepository.GetSaving( input.Code );

            if ( details == null )
            {
                throw new Exception( "Account " + input.Code + " couldnt be found." );
            }

            return details;
        }

        /// <summary>
        /// The get current details.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CurrentAccountOut> GetCurrentDetails( AccountDetails input )
        {
            await this.Validate( input );

            var current = await this.accountRepository.GetCurrent( input.Code );

            if ( current == null )
            {
                throw new Exception( "Account " + input.Code + " couldnt be found." );
            }

            return current;
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The Argument Null Exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The Exception.
        /// </exception>
        private async Task Validate( AccountDetails input )
        {
            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            if ( input.Owner == null || input.Owner == Guid.Empty )
            {
                throw new ArgumentNullException( nameof( input.Owner ) );
            }

            if ( input.Code == null || input.Code == Guid.Empty )
            {
                throw new ArgumentNullException( nameof( input.Code ) );
            }

            var owner = await this.accountRepository.IsOwner( input.Owner, input.Code );
            if ( !owner )
            {
                throw new Exception( "Account " + input.Code + " doesnt belong to " + input.Owner + "." );
            }
        }
    }
}