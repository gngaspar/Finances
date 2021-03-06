﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EntityFramework.Caching;

    using Finances.Contract.Accounting;
    using Finances.Contract.Banking;
    using Finances.Contract.Humans;
    using Finances.Domain.Accounting;
    using Finances.Domain.Extensions;
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
        /// The human repository.
        /// </summary>
        private readonly IHumanRepository humanRepository;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private readonly Domain.ICacheProvider cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        /// <param name="humanRepository">
        /// The human repository.
        /// </param>
        /// <param name="cacheProvider">
        /// The cache Provider.
        /// </param>
        public AccountRepository( BankingDbContext bankingDbContext, IHumanRepository humanRepository, Domain.ICacheProvider cacheProvider )
        {
            this.context = bankingDbContext;
            this.humanRepository = humanRepository;
            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="accounts">
        /// The accounts.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<SimpleAccount>> List( Guid owner, List<Guid> accounts )
        {
            var listQuery = await this.context.Accounts.Where( o => o.Owner == owner && accounts.Contains( o.Code ) ).ToListAsync();
            var list = new List<SimpleAccount>();

            foreach ( var accountEntity in listQuery )
            {
                list.Add( new SimpleAccount
                {
                    Code = accountEntity.Code,
                    Type = this.IsType( accountEntity ),
                    Description = accountEntity.Description,
                    Number = accountEntity.Number,
                    Amount = accountEntity.Amount
                } );
            }

            return list;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Add( Guid owner, Guid code, CurrentAccountIn input )
        {
            var account = new CurrentAccountEntity
            {
                Code = code,
                Owner = owner,
                Holder = input.Holder,
                IsArchived = input.IsArchived,
                Bank = input.Bank,
                Description = input.Description,
                Amount = input.Amount,
                Currency = input.Currency,
                Iban = input.Iban,
                Number = input.Number,
                StartDate = input.StartDate
            };

            this.context.Accounts.Add( account );

            foreach ( var loan in input.Loans )
            {
                this.context.Accounts.Add( GetLoans( owner, code, Guid.NewGuid(), loan ) );
            }

            foreach ( var saving in input.Savings )
            {
                this.context.Accounts.Add( GetSavings( owner, code, Guid.NewGuid(), saving ) );
            }

            var myint = await this.context.SaveChangesAsync();
            return myint;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Add( Guid owner, Guid currentAccount, Guid code, LoanAccountIn input )
        {
            var account = GetLoans( owner, currentAccount, code, input );

            this.context.Accounts.Add( account );

            var myint = await this.context.SaveChangesAsync();

            return myint;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Add( Guid owner, Guid currentAccount, Guid code, SavingAccountIn input )
        {
            var account = GetSavings( owner, currentAccount, code, input );

            this.context.Accounts.Add( account );

            var myint = await this.context.SaveChangesAsync();

            return myint;
        }

        /// <summary>
        /// The get current.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CurrentAccountOut> GetCurrent( Guid account )
        {
            var accountFromDatabase = await this.context.Accounts.FirstOrDefaultAsync( i => i.Code == account );
            if ( accountFromDatabase != null )
            {
                if ( this.IsType( accountFromDatabase ) != AccountType.CurrentAccount )
                {
                    throw new InvalidCastException( "The account " + account + " is not CurrentAccount." );
                }

                var castedAccount = (CurrentAccountEntity) accountFromDatabase;

                IQueryable<AccountEntity> listQuery = this.context.Accounts.Where( o => o.Owner == castedAccount.Owner );

                var loansList = await listQuery.Where( i => i is LoanAccountEntity ).ToListAsync();

                var savingList = await listQuery.Where( i => i is SavingAccountEntity ).ToListAsync();

                var holder = await this.humanRepository.Get( accountFromDatabase.Owner, accountFromDatabase.Holder );

                var listLoans = loansList.Where( u => ( (LoanAccountEntity) u ).LoanRelatedAccount == account ).Select( loan => this.GetLoanOut( (LoanAccountEntity) loan, holder ) ).ToList();
                var listSaving = savingList.Where( u => ( (SavingAccountEntity) u ).SavingRelatedAccount == account ).Select( loan => this.GetSavingOut( (SavingAccountEntity) loan, holder ) ).ToList();

                return new CurrentAccountOut
                {
                    Currency = this.cacheProvider.Currencies.FirstOrDefault( o => o.Code == accountFromDatabase.Currency ),
                    Amount = accountFromDatabase.Amount,
                    ChangeAt = accountFromDatabase.ChangeAt,
                    StartDate = accountFromDatabase.StartDate,
                    Bank = this.cacheProvider.Banks.FirstOrDefault( o => o.Code == accountFromDatabase.Bank ),
                    CreatedAt = accountFromDatabase.CreatedAt,
                    Description = accountFromDatabase.Description,
                    Holder = holder,
                    Iban = castedAccount.Iban,
                    IsArchived = accountFromDatabase.IsArchived,
                    Number = accountFromDatabase.Number,
                    Loans = listLoans,
                    Savings = listSaving
                };
            }

            return null;
        }

        /// <summary>
        /// The get loan.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<LoanAccountOut> GetLoan( Guid account )
        {
            var accountFromDatabase = await this.context.Accounts.FirstOrDefaultAsync( i => i.Code == account );
            if ( accountFromDatabase == null )
            {
                return null;
            }

            if ( this.IsType( accountFromDatabase ) != AccountType.LoanAccount )
            {
                throw new InvalidCastException( "The account " + account + " is not LoanAccount." );
            }

            var holder = await this.humanRepository.Get( accountFromDatabase.Owner, accountFromDatabase.Holder );

            return this.GetLoanOut( (LoanAccountEntity) accountFromDatabase, holder );
        }

        /// <summary>
        /// The get saving.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<SavingAccountOut> GetSaving( Guid account )
        {
            var accountFromDatabase = await this.context.Accounts.FirstOrDefaultAsync( i => i.Code == account );
            if ( accountFromDatabase == null )
            {
                return null;
            }

            if ( this.IsType( accountFromDatabase ) != AccountType.SavingAccount )
            {
                throw new InvalidCastException( "The account " + account + " is not SavingAccount." );
            }

            var holder = await this.humanRepository.Get( accountFromDatabase.Owner, accountFromDatabase.Holder );

            return this.GetSavingOut( (SavingAccountEntity) accountFromDatabase, holder );
        }

        /// <summary>
        /// The is owner.
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
        public async Task<bool> IsOwner( Guid owner, Guid account )
        {
            var exist = await this.context.Accounts.CountAsync( b => b.Code == account && b.Owner == owner );
            return exist == 1;
        }

        /// <summary>
        /// The is type.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<AccountType> IsType( Guid account )
        {
            var accountEntity = await this.context.Accounts.FirstOrDefaultAsync( i => i.Code == account );
            return this.IsType( accountEntity );
        }

        /// <summary>
        /// The is type.
        /// </summary>
        /// <param name="accountEntity">
        /// The account entity.
        /// </param>
        /// <returns>
        /// The <see cref="AccountType"/>.
        /// </returns>
        /// <exception cref="InvalidCastException">
        /// The Invalid Cast Exception.
        /// </exception>
        public AccountType IsType( AccountEntity accountEntity )
        {
            if ( accountEntity is CurrentAccountEntity )
            {
                return AccountType.CurrentAccount;
            }

            if ( accountEntity is LoanAccountEntity )
            {
                return AccountType.LoanAccount;
            }

            if ( accountEntity is SavingAccountEntity )
            {
                return AccountType.SavingAccount;
            }

            throw new InvalidCastException( "Account cant be cast." );
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="input">The input.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<AccountListResponse> List( Guid owner, AccountListRequest input )
        {
            IQueryable<AccountEntity> listQuery = this.context.Accounts.Where( o => o.Owner == owner
                         && ( ( !input.Filter.BringArchived && !o.IsArchived ) || input.Filter.BringArchived ) );

            if ( !string.IsNullOrEmpty( input.Filter.Description ) )
            {
                listQuery = input.Filter.DescriptionExact ?
                        listQuery.Where( x => x.Description == input.Filter.Description ) :
                        listQuery.Where( x => x.Description.Contains( input.Filter.Description ) );
            }

            if ( input.Filter.FilterByBank )
            {
                listQuery = listQuery.Where( x => x.Bank == input.Filter.Bank );
            }

            if ( input.Filter.FilterByCurrency && !string.IsNullOrEmpty( input.Filter.Currency ) )
            {
                listQuery = listQuery.Where( x => x.Currency == input.Filter.Currency );
            }

            if ( input.Filter.FilterByHolder && !input.Filter.BringOnlyMine )
            {
                listQuery = listQuery.Where( x => x.Holder == input.Filter.Holder );
            }

            if ( input.Filter.BringOnlyMine )
            {
                listQuery = listQuery.Where( x => x.Holder == owner );
            }

            if ( !string.IsNullOrEmpty( input.Filter.Number ) )
            {
                listQuery = listQuery.Where( x => x.Number.Contains( input.Filter.Number ) );
            }

            listQuery = listQuery.Where( x =>
                 ( input.Filter.Types.Contains( AccountType.CurrentAccount ) && x is CurrentAccountEntity )
                 || ( input.Filter.Types.Contains( AccountType.LoanAccount ) && x is LoanAccountEntity )
                 || ( input.Filter.Types.Contains( AccountType.SavingAccount ) && x is SavingAccountEntity ) );

            var queryResult = await listQuery.CountAsync();

            var orderType = input.Order.IsDesc ? SortOrder.Descending : SortOrder.Ascending;

            var list = await listQuery
                        .OrderByFieldAccount( orderType, input.Order.Field )
                        .Skip( ( input.Page - 1 ) * input.ItemsPerPage )
                        .Take( input.ItemsPerPage )
                        .Select( order => new
                        {
                            order.Code,
                            order.StartDate,
                            order.Number,
                            order.Description,
                            order.Currency,
                            order.Amount,
                            order.Holder,
                            order.Bank,
                            order.ChangeAt,
                            order.CreatedAt,
                            order.IsArchived,
                            Type = order is CurrentAccountEntity ? AccountType.CurrentAccount : order is LoanAccountEntity ? AccountType.LoanAccount : AccountType.SavingAccount
                        } ).ToListAsync();

            var lisOfGuids = list.GroupBy( o => o.Holder ).Select( g => g.Key ).ToList();

            var listOfHolders = await this.humanRepository.GetList( owner, lisOfGuids );

            var result = new AccountListResponse
            {
                NumberOfItems = queryResult,
                Data = list.Select( order => new Account
                {
                    Code = order.Code,
                    StartDate = order.StartDate,
                    Number = order.Number,
                    Description = order.Description,
                    Currency = this.cacheProvider.Currencies.FirstOrDefault( o => o.Code == order.Currency ),
                    Amount = order.Amount,
                    Holder = listOfHolders.FirstOrDefault( i => i.Code == order.Holder ),
                    Bank = this.cacheProvider.Banks.FirstOrDefault( o => o.Code == order.Bank ),
                    ChangeAt = order.ChangeAt,
                    CreatedAt = order.CreatedAt,
                    IsArchived = order.IsArchived,
                    Type = order.Type
                } ).ToList()
            };

            return result;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// The get loans.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="LoanAccountEntity"/>.
        /// </returns>
        private static LoanAccountEntity GetLoans( Guid owner, Guid currentAccount, Guid code, LoanAccountIn input )
        {
            var output = new LoanAccountEntity
            {
                Code = code,
                Owner = owner,
                Holder = input.Holder,
                IsArchived = input.IsArchived,
                Bank = input.Bank,
                Description = input.Description,
                Amount = input.Amount,
                Currency = input.Currency,
                Number = input.Number,
                StartDate = input.StartDate,
                InitialAmount = input.InitialAmount,
                InterestNetRate = input.InterestNetRate,
                LoanInterestRate = input.LoanInterestRate,
                PremiumPercentage = input.PremiumPercentage,
                LoanEndDate = input.LoanEndDate
            };

            if ( currentAccount != Guid.Empty )
            {
                output.LoanRelatedAccount = currentAccount;
            }

            return output;
        }

        /// <summary>
        /// The get savings.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="SavingAccountEntity"/>.
        /// </returns>
        private static SavingAccountEntity GetSavings( Guid owner, Guid currentAccount, Guid code, SavingAccountIn input )
        {
            var output = new SavingAccountEntity
            {
                Code = code,
                Owner = owner,
                Holder = input.Holder,
                IsArchived = input.IsArchived,
                Bank = input.Bank,
                Description = input.Description,
                Amount = input.Amount,
                Currency = input.Currency,
                Number = input.Number,
                StartDate = input.StartDate,
                AutomaticRenovation = input.AutomaticRenovation,
                InterestCapitalization = input.InterestCapitalization,
                InterestPayment = input.InterestPayment,
                SavingEndDate = input.SavingEndDate,
                SavingInterestRate = input.SavingInterestRate
            };

            if ( currentAccount != Guid.Empty )
            {
                output.SavingRelatedAccount = currentAccount;
            }

            return output;
        }

        /// <summary>
        /// The get saving out.
        /// </summary>
        /// <param name="a">
        /// The account.
        /// </param>
        /// <param name="holder">
        /// The holder.
        /// </param>
        /// <returns>
        /// The <see cref="SavingAccountOut"/>.
        /// </returns>
        private SavingAccountOut GetSavingOut( SavingAccountEntity a, HumanOut holder )
        {
            return new SavingAccountOut
            {
                ChangeAt = a.ChangeAt,
                Currency = this.cacheProvider.Currencies.FirstOrDefault( o => o.Code == a.Currency ),
                StartDate = a.StartDate,
                Amount = a.Amount,
                Bank = this.cacheProvider.Banks.FirstOrDefault( o => o.Code == a.Bank ),
                Description = a.Description,
                CreatedAt = a.CreatedAt,
                Holder = holder,
                IsArchived = a.IsArchived,
                Number = a.Number,
                AutomaticRenovation = a.AutomaticRenovation,
                InterestCapitalization = a.InterestCapitalization,
                InterestPayment = a.InterestPayment,
                SavingEndDate = a.SavingEndDate,
                SavingInterestRate = a.SavingInterestRate
            };
        }

        /// <summary>
        /// The get loan out.
        /// </summary>
        /// <param name="a">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="LoanAccountOut"/>.
        /// </returns>
        private LoanAccountOut GetLoanOut( LoanAccountEntity a, HumanOut humanOut )
        {
            var output = new LoanAccountOut
            {
                ChangeAt = a.ChangeAt,
                Currency = this.cacheProvider.Currencies.FirstOrDefault( o => o.Code == a.Currency ),
                StartDate = a.StartDate,
                Amount = a.Amount,
                Bank = this.cacheProvider.Banks.FirstOrDefault( o => o.Code == a.Bank ),
                Description = a.Description,
                CreatedAt = a.CreatedAt,
                IsArchived = a.IsArchived,
                Number = a.Number,
                InitialAmount = a.InitialAmount,
                InterestNetRate = a.InterestNetRate,
                LoanEndDate = a.LoanEndDate,
                Holder = humanOut,
                LoanInterestRate = a.LoanInterestRate,
                PremiumPercentage = a.PremiumPercentage,
            };


            return output;
        }
    }
}