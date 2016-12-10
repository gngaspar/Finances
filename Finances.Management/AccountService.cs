﻿namespace Finances.Management
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;
    using Finances.Domain;
    using Finances.Domain.Repository;

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
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// The list.
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
        /// The argument null exception.
        /// </exception>
        public async Task<AccountListResponse> List(Guid owner, AccountListRequest input)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //TODO: Add validations

            return await this.accountRepository.List(owner, input);
        }

        public async Task<Guid> AddCurrentAccount(Guid owner, CurrentAccountIn input)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //TODO: Add validations


            var currentGuid = Guid.NewGuid();

            var result = await this.accountRepository.Add(owner, currentGuid, input);

            return result != 0 ? currentGuid : Guid.Empty;

        }

        public Task<Guid> AddSavingAccount(Guid owner, Guid currentAccount, SavingAccountIn input)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> AddLoanAccount(Guid owner, Guid currentAccount, LoanAccountIn input)
        {
            throw new NotImplementedException();
        }
    }
}