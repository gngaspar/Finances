﻿namespace Finances.Management
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;

    public class BankService : IBankService
    {
        private readonly IBankRepository bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public async Task<ActionResponse> Add(BankIn bank)
        {
            if (bank == null)
            {
                throw new NullReferenceException("Bank must not be null.");
            }

            var response = new ActionResponse();
            response.Type = ActionType.Creation;

            var result = await this.bankRepository.Add(bank);

            return response;
        }

        public async Task<ActionResponse> Edit(BankOut bank)
        {
            if (bank == null)
            {
                throw new NullReferenceException("Bank must not be null.");
            }

            throw new System.NotImplementedException();
        }

        public async Task<BankListResponse> List(BankListRequest request)
        {
            if (request == null)
            {
                throw new NullReferenceException("Request must not be null.");
            }

            if (request.Page == 0)
            {
                throw new Exception("Page must be bigger then 0.");
            }

            if (request.ItemsPerPage == 0)
            {
                throw new Exception("ItemsPerPage must be bigger then 0.");
            }

            if (request.Filter == null)
            {
                throw new Exception("Filter cant be null.");
            }

            return await this.bankRepository.List(request);
        }
    }
}