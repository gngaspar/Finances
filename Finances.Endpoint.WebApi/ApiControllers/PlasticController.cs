// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlasticController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the PlasticController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Finances.Contract;
    using Finances.Contract.Plastics;
    using Finances.Domain;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The Plastic Controller.
    /// </summary>
    [RoutePrefix( "Plastic" )]
    public class PlasticController : BaseController, IPlasticController
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IPlasticService plasticService;

        public PlasticController( IPlasticService plasticService )
        {
            this.plasticService = plasticService;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/List" )]
        [ResponseType( typeof( ActionResponse<CardListResponse> ) )]
        public async Task<HttpResponseMessage> List( Guid owner, CardListRequest input )
        {
            return await this.ProcessActionAsync( owner, input, this.plasticService.List );
        }
    }
}
