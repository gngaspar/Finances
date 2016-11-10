namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;
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
            var listQuery = this.context.Banks;

            var list = await listQuery
                .OrderBy(x => x.Name)
                .Skip((parameters.Page - 1) * parameters.ItemsPerPage)
                .Take(parameters.ItemsPerPage + 1)
                .Select(order => new BankOut()
                {
                    Code = order.Code,
                    Name = order.Name
                })
                .ToListAsync();

            var result = new BankListResponse
            {
                NumberOfItems = list.Count,
                Data = list.ToArray()
            };

            return result;
        }
    }
}