namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain.Banking;
    using Finances.Domain.Repository;

    public class BankRepository : IBankRepository
    {
        private readonly BankingDbContext context;

        public BankRepository()
        {
            this.context = new BankingDbContext();
        }

        internal BankRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        public async Task<ActionResponse> Add(BankIn parameters)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<ActionResponse> Edit(BankIn parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<BankOut> Get(Guid parameters)
        {
            throw new NotImplementedException();
        }

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

            var list = await listQuery
                .OrderBy(x => x.Name)
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
    }
}