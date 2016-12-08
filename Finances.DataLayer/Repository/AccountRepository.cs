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
        public async Task<AccountListResponse> List(Guid owner, AccountListRequest input)
        {
            IQueryable<AccountEntity> listQuery = this.context.Accounts.Where(o => o.Owner == owner
                        && ((!input.Filter.BringArchived && !o.IsArchived) || input.Filter.BringArchived));

            if (!string.IsNullOrEmpty(input.Filter.Description))
            {
                listQuery = input.Filter.DescriptionExact ?
                        listQuery.Where(x => x.Description == input.Filter.Description) :
                        listQuery.Where(x => x.Description.Contains(input.Filter.Description));
            }

            if (input.Filter.FilterByBank)
            {
                listQuery = listQuery.Where(x => x.Bank == input.Filter.Bank);
            }

            if (input.Filter.FilterByCurrency && !string.IsNullOrEmpty(input.Filter.Currency))
            {
                listQuery = listQuery.Where(x => x.Currency == input.Filter.Currency);
            }

            if (input.Filter.FilterByHolder && !input.Filter.BringOnlyMine)
            {
                listQuery = listQuery.Where(x => x.Holder == input.Filter.Holder);
            }

            if (input.Filter.BringOnlyMine)
            {
                listQuery = listQuery.Where(x => x.Holder == owner);
            }

            if (!string.IsNullOrEmpty(input.Filter.Number))
            {
                listQuery = listQuery.Where(x => x.Number.Contains(input.Filter.Number));
            }
            
            listQuery = listQuery.Where(x => 
                (input.Filter.Types.Contains(AccountType.CurrentAccount) && x is CurrentAccountEntity)
                || (input.Filter.Types.Contains(AccountType.LoanAccount) && x is LoanAccountEntity)
                || (input.Filter.Types.Contains(AccountType.SavingAccount) && x is SavingAccountEntity));

            var queryResult = await listQuery.CountAsync();

            var orderType = input.Order.IsDesc ? SortOrder.Descending : SortOrder.Ascending;

            var list = await listQuery
                        .OrderByFieldAccount(orderType, input.Order.Field)
                        .Skip((input.Page - 1) * input.ItemsPerPage)
                        .Take(input.ItemsPerPage)
                        .Select(order => new Account
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
                        }).ToListAsync();

            var result = new AccountListResponse
            {
                NumberOfItems = queryResult,
                Data = list
            };

            return result;
        }
    }
}