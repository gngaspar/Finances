namespace Finances.Management
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Humans;
    using Finances.Domain;
    using Finances.Domain.Repository;

    public class HumanService : IHumanService
    {
        /// <summary>
        /// The currency repository
        /// </summary>
        private readonly IHumanRepository humanRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanService"/> class.
        /// </summary>
        /// <param name="humanRepository">
        /// The human repository.
        /// </param>
        public HumanService(IHumanRepository humanRepository)
        {
            this.humanRepository = humanRepository;
        }

        public async Task<Guid> Add(Guid code, HumanIn input)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //TODO: Add validations

            var ownerExits = await this.humanRepository.ExistOwner(code);
            if (!ownerExits)
            {
                throw new Exception("User doesnt exist.");
            }

            var exits = await this.humanRepository.Exist(code);
            if (!exits)
            {
                throw new Exception("User person doesnt exist.");
            }

            var newCode = Guid.NewGuid();

            var created = await this.humanRepository.Add(code, newCode, input);

            return created != 0 ? newCode : Guid.Empty;
        }

        public async Task<bool> Edit(Guid code, Guid human, HumanIn input)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            if (human == null)
            {
                throw new ArgumentNullException(nameof(human));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //TODO: Add validations

            var ownerExits = await this.humanRepository.ExistOwner(code);
            if (!ownerExits)
            {
                throw new Exception("User doesnt exist.");
            }


            var exits = await this.humanRepository.Exist(code);
            if (!exits)
            {
                throw new Exception("User person doesnt exist.");
            }


            var exitsHuman = await this.humanRepository.Exist(human);
            if (!exits)
            {
                throw new Exception("User to change doesnt exist.");
            }


            var changed = await this.humanRepository.Edit(code, human, input);

            return changed != 0;
        }

        public async Task<HumanListResponse> List(Guid code, HumanListRequest input)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //TODO: Add validations

            var ownerExits = await this.humanRepository.ExistOwner(code);
            if (!ownerExits)
            {
                throw new Exception("User doesnt exist.");
            }
            
            var exits = await this.humanRepository.Exist(code);
            if (!exits)
            {
                throw new Exception("User person doesnt exist.");
            }

            return await this.humanRepository.List(code, input);
        }
    }
}