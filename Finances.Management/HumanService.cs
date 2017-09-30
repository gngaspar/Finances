// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The human service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Management
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Humans;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The human service.
    /// </summary>
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
        public HumanService( IHumanRepository humanRepository )
        {
            this.humanRepository = humanRepository;
        }

        /// <summary>
        /// The add.
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
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<Guid> Add( Guid owner, HumanIn input )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( nameof( owner ) );
            }

            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            // TODO: Add validations
            var ownerExits = await this.humanRepository.ExistOwner( owner );
            if ( !ownerExits )
            {
                throw new Exception( "User doesnt exist." );
            }

            var newCode = Guid.NewGuid();

            var created = await this.humanRepository.Add( owner, newCode, input );

            return created != 0 ? newCode : Guid.Empty;
        }

        /// <summary>
        /// The edit.
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
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<bool> Edit( Guid owner, HumanEdit input )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( nameof( owner ) );
            }

            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            if ( input.Human == null )
            {
                throw new ArgumentNullException( nameof( input.Human ) );
            }

            if ( input.Code == null )
            {
                throw new ArgumentNullException( nameof( input.Code ) );
            }

            //TODO: Add validations
            var ownerExits = await this.humanRepository.ExistOwner( owner );
            if ( !ownerExits )
            {
                throw new Exception( "User doesnt exist." );
            }

            var exitsHuman = await this.humanRepository.Exist( input.Code );
            if ( !exitsHuman )
            {
                throw new Exception( "User to change doesnt exist." );
            }

            var confirmIfIsOwner = await this.humanRepository.IsHeOwner( owner, input.Code );
            if ( !confirmIfIsOwner )
            {
                throw new Exception( "User is not owner." );
            }

            var changed = await this.humanRepository.Edit( input.Code, input.Human );

            return changed != 0;
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
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<HumanListResponse> List( Guid owner, HumanListRequest input )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( nameof( owner ) );
            }

            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            //TODO: Add validations
            var ownerExits = await this.humanRepository.ExistOwner( owner );
            if ( !ownerExits )
            {
                throw new Exception( "User doesnt exist." );
            }

            return await this.humanRepository.List( owner, input );
        }
    }
}