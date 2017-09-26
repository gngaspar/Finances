// --------------------------------------------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;
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
        internal AccountRepository( BankingDbContext bankingDbContext )
        {
            this.context = bankingDbContext;
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
        public Task<CurrentAccountOut> GetCurrent( Guid account )
        {
            throw new NotImplementedException();
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
        public Task<LoanAccountOut> GetLoan( Guid account )
        {
            throw new NotImplementedException();
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
        public Task<SavingAccountOut> GetSaving( Guid account )
        {
            throw new NotImplementedException();
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
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
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
                        .Select( order => new Account
                        {
                            Code = order.Code,
                            StartDate = order.StartDate,
                            Number = order.Number,
                            Description = order.Description,
                            Currency = order.Currency,
                            Amount = order.Amount,
                            Holder = order.Holder,
                            Bank = order.Bank,
                            ChangeAt = order.ChangeAt,
                            CreatedAt = order.CreatedAt,
                            IsArchived = order.IsArchived,
                            Type = order is CurrentAccountEntity ? AccountType.CurrentAccount : order is LoanAccountEntity ? AccountType.LoanAccount : AccountType.SavingAccount
                        } ).ToListAsync();

            var result = new AccountListResponse
            {
                NumberOfItems = queryResult,
                Data = list
            };

            return result;
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
            return new LoanAccountEntity
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
                LoanRelatedAccount = currentAccount,
                PremiumPercentage = input.PremiumPercentage,
                LoanEndDate = input.LoanEndDate
            };
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
            return new SavingAccountEntity
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
                SavingRelatedAccount = currentAccount,
                AutomaticRenovation = input.AutomaticRenovation,
                InterestCapitalization = input.InterestCapitalization,
                InterestPayment = input.InterestPayment,
                SavingEndDate = input.SavingEndDate,
                SavingInterestRate = input.SavingInterestRate
            };
        }
    }
}