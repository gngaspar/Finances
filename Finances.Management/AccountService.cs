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
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountRepository">
        /// The repository.
        /// </param>
        public AccountService( IAccountRepository accountRepository )
        {
            this.accountRepository = accountRepository;
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
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Guid> AddSavingAccount( Guid owner, Guid currentAccount, SavingAccountIn input )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add loan account.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Guid> AddLoanAccount( Guid owner, Guid currentAccount, LoanAccountIn input )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get loan details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<LoanAccountOut> GetLoanDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get saving details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<SavingAccountOut> GetSavingDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
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
        public async Task<CurrentAccountOut> GetCurrentDetails( CurrentDetails input )
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

            //TODO: Add validations
            var current = await this.accountRepository.GetCurrent( input.Code );

            return current;
        }
    }
}