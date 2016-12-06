﻿namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using Finances.Contract.Humans;
    using Finances.DataLayer.Extension;
    using Finances.Domain.Extensions;
    using Finances.Domain.Human;
    using Finances.Domain.Repository;

    /// <summary>
    /// The human repository.
    /// </summary>
    public class HumanRepository : IHumanRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BankingDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanRepository"/> class.
        /// </summary>
        public HumanRepository()
        {
            this.context = new BankingDbContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        internal HumanRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        /// <summary>
        /// The exist.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> Exist(Guid input)
        {
            var exist = await this.context.Persons.CountAsync(b => b.Code == input);
            return exist == 1;
        }

        /// <summary>
        /// The exist owner.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ExistOwner(Guid input)
        {
            var exist = await this.context.Users.CountAsync(b => b.Code == input);
            var existUser = await this.Exist(input);
            return exist == 1 && existUser;
        }

        /// <summary>
        /// The is he owner.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> IsHeOwner(Guid owner, Guid code)
        {
            var exist = await this.context.Persons.CountAsync(b => b.Code == code && b.OwnerCode == owner);
            return exist == 1;
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
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Edit(Guid code, HumanIn input)
        {
            var person = new PersonEntity
            {
                Code = code,
                Name = input.Name,
                Surname = input.Surname,
                Email = input.Email
            };

            this.context.SeedAddOrUpdate(p => p.Code, p => new { p.Name, p.Surname, p.Email, p.ChangeAt }, person);

            var myint = await this.context.SaveChangesAsync();
            return myint;
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
        public async Task<HumanListResponse> List(Guid owner, HumanListRequest input)
        {
            IQueryable<PersonEntity> listQuery = this.context.Persons.Where(i => !i.IsMe && i.OwnerCode == owner);

            if (!string.IsNullOrEmpty(input.Filter.AnyName))
            {
                listQuery = input.Filter.AnyNameExact ?
                        listQuery.Where(x => x.Name == input.Filter.AnyName || x.Surname == input.Filter.AnyName) :
                        listQuery.Where(x => x.Name.Contains(input.Filter.AnyName) || x.Surname.Contains(input.Filter.AnyName));
            }

            if (!string.IsNullOrEmpty(input.Filter.Email))
            {
                listQuery = input.Filter.EmailExact ?
                        listQuery.Where(x => x.Name == input.Filter.Email) :
                        listQuery.Where(x => x.Email.Contains(input.Filter.Email));
            }

            var queryResult = await listQuery.CountAsync();

            var orderType = input.Order.IsDesc ? SortOrder.Descending : SortOrder.Ascending;

            var list = await listQuery
                        .OrderByFieldPerson(orderType, input.Order.Field)
                        .Skip((input.Page - 1) * input.ItemsPerPage)
                        .Take(input.ItemsPerPage)
                        .Select(order => new HumanOut
                        {
                            Code = order.Code,
                            Name = order.Name,
                            Email = order.Email,
                            Surname = order.Surname,
                            ChangeAt = order.ChangeAt,
                            CreatedAt = order.CreatedAt
                        }).ToListAsync();

            var result = new HumanListResponse
            {
                NumberOfItems = queryResult,
                Data = list
            };

            return result;
        }
    }
}