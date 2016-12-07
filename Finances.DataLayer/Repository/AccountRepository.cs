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
        /// <param name="holder">
        /// The holder.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<AccountListResponse> List(Guid owner, Guid holder, AccountListRequest input)
        {
            IQueryable<AccountEntity> listQuery = this.context.Accounts.Where(o => o.Owner == owner
                        && o.Holder == holder
                        && o is CurrentAccountEntity 
                        && ((!input.Filter.BringArchived && !o.IsArchived) || input.Filter.BringArchived));

            if (!string.IsNullOrEmpty(input.Filter.Description))
            {
                listQuery = input.Filter.DescriptionExact ?
                        listQuery.Where(x => x.Description == input.Filter.Description) :
                        listQuery.Where(x => x.Description.Contains(input.Filter.Description));
            }

            var queryResult = await listQuery.CountAsync();

            var orderType = input.Order.IsDesc ? SortOrder.Descending : SortOrder.Ascending;

            var list = await listQuery
                        .OrderByFieldAccount(orderType, input.Order.Field)
                        .Skip((input.Page - 1) * input.ItemsPerPage)
                        .Take(input.ItemsPerPage)
                        .Select(order => new AccountItem
                        {
                            Code = order.Code,
                            Description = order.Description,
                            ChangeAt = order.ChangeAt,
                            CreatedAt = order.CreatedAt
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