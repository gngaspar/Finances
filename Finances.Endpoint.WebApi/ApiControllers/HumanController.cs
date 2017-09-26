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
    using System.Threading.Tasks;
    using System.Web.Http;

    using Finances.Contract;
    using Finances.Contract.Humans;
    using Finances.Domain;

    /// <summary>
    /// The human Controller
    /// </summary>
    /// <seealso cref="ApiController"/>
    /// <seealso cref="IHumanController"/>
    [RoutePrefix( "Human" )]
    public class HumanController : ApiController, IHumanController
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IHumanService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public HumanController( IHumanService service )
        {
            this.service = service;
        }

        /// <summary>
        /// The add.
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
        [HttpPost]
        [Route( "{code:guid}/Add" )]
        public async Task<ActionResponse<Guid>> Add( Guid code, HumanIn input )
        {
            var result = new ActionResponse<Guid> { HasError = false };
            try
            {
                result.Results = await this.service.Add( code, input );
            }
            catch ( Exception ex )
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
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
        [Route( "{code:guid}/Edit/{human:guid}" )]
        public async Task<ActionResponse<bool>> Edit( Guid code, Guid human, HumanIn input )
        {
            var result = new ActionResponse<bool> { HasError = false };
            try
            {
                result.Results = await this.service.Edit( code, human, input );
            }
            catch ( Exception ex )
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The list.
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
        [HttpPost]
        [Route( "{code:guid}/List" )]
        public async Task<ActionResponse<HumanListResponse>> List( Guid code, HumanListRequest input )
        {
            var result = new ActionResponse<HumanListResponse> { HasError = false };
            try
            {
                result.Results = await this.service.List( code, input );
            }
            catch ( Exception ex )
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}