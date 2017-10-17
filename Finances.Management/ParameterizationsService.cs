// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizationsService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the ParameterizationsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Management
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Finances.Contract.Parameterizations;
    using Finances.Domain;
    using Finances.Domain.Repository;

    /// <summary>
    /// The parameterizations service.
    /// </summary>
    public class ParameterizationsService : IParameterizationsService
    {
        /// <summary>
        /// The parameterizations repository.
        /// </summary>
        private IParameterizationsRepository parameterizationsRepository;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private ICacheProvider cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterizationsService"/> class.
        /// </summary>
        /// <param name="parameterizationsRepository">
        /// The parameterizations repository.
        /// </param>
        /// <param name="cacheProvider">
        /// The cache Provider.
        /// </param>
        public ParameterizationsService( IParameterizationsRepository parameterizationsRepository, ICacheProvider cacheProvider )
        {
            this.cacheProvider = cacheProvider;
            this.parameterizationsRepository = parameterizationsRepository;
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
        public async Task<int> Add( Guid owner, ParameterizationIn input )
        {
            if ( owner == null || owner == Guid.Empty )
            {
                throw new ArgumentNullException( nameof( owner ) );
            }

            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            if ( !this.cacheProvider.Currencies.Select( x => x.Code ).Contains( input.Currency ) )
            {
                throw new Exception( "The currency " + input.Currency + " doesnt look valid." );
            }

            if ( ( input.FromAccount == null || input.FromAccount == Guid.Empty ) && ( input.Children != null || input.Children.Count >= 1 ) )
            {
                throw new Exception( "If FromAccount is null, no Children are allowed." );
            }

            // TODO More validations !!! 

            return await this.parameterizationsRepository.Add( owner, input );
        }
    }
}