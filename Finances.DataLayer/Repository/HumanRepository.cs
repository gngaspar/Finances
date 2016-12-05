namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Finances.Contract.Humans;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;
    using Finances.Domain.Repository;

    public class HumanRepository : IHumanRepository
    {
        private readonly BankingDbContext context;

        public HumanRepository()
        {
            this.context = new BankingDbContext();
        }

        internal HumanRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        public async Task<bool> Exist(Guid input)
        {
            var exist = await this.context.Persons.CountAsync(b => b.Code == input);
            return exist != 0;
        }

        public async Task<bool> ExistOwner(Guid input)
        {
            var exist = await this.context.Users.CountAsync(b => b.Code == input);
            return exist != 0;
        }

        public async Task<int> Add(Guid owner, Guid code, HumanIn input)
        {
            var newPerson = new PersonEntity
            {
                Code = code,
                OwnerCode = owner,
                Name = input.Name,
                Surname = input.Surname,
                Email = input.Email,
                IsArchived = false
            };

            this.context.Persons.Add(newPerson);
            var myint = await this.context.SaveChangesAsync();

            return myint;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Task<int> Edit(Guid owner, Guid code, HumanIn input)
        {
            throw new NotImplementedException();
        }

        public Task<HumanListResponse> List(Guid owner, HumanListRequest input)
        {
            throw new NotImplementedException();
        }
    }
}