// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The human Controller
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
    using Finances.Contract.Humans;
    using Finances.Domain;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The human Controller
    /// </summary>
    /// <seealso cref="ApiController"/>
    /// <seealso cref="IHumanController"/>
    [RoutePrefix( "Human" )]
    public class HumanController : BaseController, IHumanController
    {
        /// <summary>
        /// The human Service.
        /// </summary>
        private readonly IHumanService humanService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public HumanController( IHumanService humanService )
        {
            this.humanService = humanService;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B .
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/Add" )]
        [ResponseType( typeof( ActionResponse<Guid> ) )]
        public async Task<HttpResponseMessage> Add( Guid owner, HumanIn input )
        {
            return await this.ProcessActionAsync( owner, input, this.humanService.Add );
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B .
        /// </param>
        /// <param name="human">
        /// The human.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/Edit/{human:guid}" )]
        [ResponseType( typeof( ActionResponse<bool> ) )]
        public async Task<HttpResponseMessage> Edit( Guid owner, Guid human, HumanIn input )
        {
            var result = new HumanEdit { Code = human, Human = input };
            return await this.ProcessActionAsync( owner, result, this.humanService.Edit );
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B .
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/List" )]
        [ResponseType( typeof( ActionResponse<HumanListResponse> ) )]
        public async Task<HttpResponseMessage> List( Guid owner, HumanListRequest input )
        {
            this.Validator.Page( input ).Items( input );
            return await this.ProcessActionAsync( owner, input, this.humanService.List );
        }
    }
}