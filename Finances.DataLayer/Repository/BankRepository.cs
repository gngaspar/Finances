namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.DataLayer.Extension;
    using Finances.Domain.Banking;
    using Finances.Domain.Extensions;
    using Finances.Domain.Repository;

    /// <summary>
    /// The bank repository.
    /// </summary>
    public class BankRepository : IBankRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BankingDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRepository"/> class.
        /// </summary>
        public BankRepository()
        {
            this.context = new BankingDbContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        internal BankRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Add(Guid code, BankIn bank)
        {
            var newBank = new BankEntity
            {
                Code = code,
                Swift = bank.Swift,
                Country = bank.Country,
                Name = bank.Name,
                Url = bank.Url
            };

            this.context.Entry(newBank).State = EntityState.Added;
            var myint = await this.context.SaveChangesAsync();

            return myint;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Edit(Guid code, BankIn bank)
        {
            var newBank = new BankEntity
            {
                Code = code,
                Swift = bank.Swift,
                Country = bank.Country,
                Name = bank.Name,
                Url = bank.Url
            };

            this.context.SeedAddOrUpdate(p => p.Code, p => new { p.Name, p.Swift, p.Country, p.Url, p.ChangeAt }, newBank);

            var myint = await this.context.SaveChangesAsync();
            return myint;
        }

        /// <summary>
        /// The exists by code.
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ExistsByCode(Guid guid)
        {
            var exist = await this.context.Banks.CountAsync(b => b.Code == guid);
            return exist == 1;
        }

        /// <summary>
        /// The exists by swift.
        /// </summary>
        /// <param name="swift">
        /// The swift.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ExistsBySwift(string swift)
        {
            var exist = await this.context.Banks.CountAsync(b => b.Swift == swift);
            return exist == 1;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<BankListResponse> List(BankListRequest parameters)
        {
            IQueryable<BankEntity> listQuery = this.context.Banks;

            if (!string.IsNullOrEmpty(parameters.Filter.Name))
            {
                listQuery = parameters.Filter.NameExact ?
                        listQuery.Where(x => x.Name == parameters.Filter.Name) :
                        listQuery.Where(x => x.Name.Contains(parameters.Filter.Name));
            }

            if (!string.IsNullOrEmpty(parameters.Filter.Swift))
            {
                listQuery = parameters.Filter.SwiftExact ?
                        listQuery.Where(x => x.Name == parameters.Filter.Swift) :
                        listQuery.Where(x => x.Swift.Contains(parameters.Filter.Swift));
            }

            var queryResult = await listQuery.CountAsync();

            var orderType = parameters.Order.IsDesc ? SortOrder.Descending : SortOrder.Ascending;

            var list = await listQuery
                        .OrderByFieldBank(orderType, parameters.Order.Field)
                        .Skip((parameters.Page - 1) * parameters.ItemsPerPage)
                        .Take(parameters.ItemsPerPage)
                        .Select(order => new BankOut
                        {
                            Code = order.Code,
                            Name = order.Name,
                            Country = order.Country,
                            Url = order.Url,
                            Swift = order.Swift,
                            ChangeAt = order.ChangeAt,
                            CreatedAt = order.CreatedAt
                        }).ToListAsync();

            var result = new BankListResponse
            {
                NumberOfItems = queryResult,
                Data = list
            };

            return result;
        }

        /// <summary>
        /// The this swift exists in other.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="swift">
        /// The swift.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ThisSwiftExistsInOther(Guid code, string swift)
        {
            var exist = await this.context.Banks.CountAsync(b => b.Swift == swift && b.Code != code);
            return exist == 1;
        }
    }
}