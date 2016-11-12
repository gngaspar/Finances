namespace Finances.Management
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
            ValidateBankIn(bank);

            var existBySwift = await this.bankRepository.ExistsBySwift(bank.Swift);
            if (existBySwift)
            {
                throw new Exception($"Swift {bank.Swift} already exists.");
            }

            var response = new ActionResponse();
            response.Type = ActionType.Creation;

            var result = await this.bankRepository.Add(bank);

            return response;
        }

        public async Task<ActionResponse> Edit(Guid code, BankIn bank)
        {
            ValidateBankIn(bank);

            var existCode = await this.bankRepository.ExistsByCode(code);
            if (!existCode)
            {
                throw new Exception($"Bank with {code} doesnt exists.");
            }

            var existInOther = await this.bankRepository.ThisSwiftExistsInOther(code, bank.Swift);
            if (!existInOther)
            {
                throw new Exception($"The Swift {bank.Swift} exists in a bank with a diferent then {code} .");
            }

            var response = new ActionResponse();
            response.Type = ActionType.Modification;

            var result = await this.bankRepository.Edit(code, bank);

            return response;
        }

        public async Task<BankListResponse> List(BankListRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
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
                throw new ArgumentNullException(nameof(request.Filter));
            }

            if (request.Order == null)
            {
                throw new ArgumentNullException(nameof(request.Order));
            }

            return await this.bankRepository.List(request);
        }

        private static void ValidateBankIn(BankIn bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException(nameof(bank));
            }

            if (string.IsNullOrEmpty(bank.Swift))
            {
                throw new NullReferenceException("Swift must not be null.");
            }

            if (bank.Swift.Length > 50)
            {
                throw new Exception("Swift is longer then 50.");
            }

            if (string.IsNullOrEmpty(bank.Country))
            {
                throw new NullReferenceException("Country must not be null.");
            }

            if (bank.Country.Length > 5)
            {
                throw new Exception("Country is longer then 5.");
            }

            if (string.IsNullOrEmpty(bank.Name))
            {
                throw new NullReferenceException("Name must not be null.");
            }

            if (bank.Name.Length > 100)
            {
                throw new Exception("Name is longer then 100.");
            }

            if (bank.Name.Length < 2)
            {
                throw new Exception("Name is smaller then 2.");
            }

            if (string.IsNullOrEmpty(bank.Url))
            {
                throw new NullReferenceException("Url must not be null.");
            }

            if (bank.Url.Length > 100)
            {
                throw new Exception("Url is longer then 250.");
            }
        }
    }
}