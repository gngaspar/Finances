// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlasticService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the PlasticService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Management
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract.Plastics;
    using Finances.Domain;
    using Finances.Domain.Repository;

    /// <summary>
    /// The plastic service.
    /// </summary>
    public class PlasticService : IPlasticService
    {
        /// <summary>
        /// The plastic repository.
        /// </summary>
        private IPlasticRepository plasticRepository;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private ICacheProvider cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlasticService"/> class.
        /// </summary>
        /// <param name="plasticRepository">
        /// The plastic repository.
        /// </param>
        /// <param name="cacheProvider">
        /// The cache provider.
        /// </param>
        public PlasticService( IPlasticRepository plasticRepository, ICacheProvider cacheProvider )
        {
            this.plasticRepository = plasticRepository;
            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CardListResponse> List( Guid owner, CardListRequest request )
        {
            return await this.plasticRepository.List( owner, request );
        }
    }
}