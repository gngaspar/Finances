// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizationsController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the ParameterizationsController type.
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
    using Finances.Contract.Parameterizations;
    using Finances.Contract.Plastics;
    using Finances.Domain;

    /// <summary>
    /// The Parameterizations Controller.
    /// </summary>
    [RoutePrefix( "Parameterization" )]
    public class ParameterizationsController : BaseController, IParameterizationsController
    {
        /// <summary>
        /// The parameterizations service.
        /// </summary>
        private IParameterizationsService parameterizationsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterizationsController"/> class.
        /// </summary>
        /// <param name="parameterizationsService">
        /// The parameterizations service.
        /// </param>
        public ParameterizationsController( IParameterizationsService parameterizationsService )
        {
            this.parameterizationsService = parameterizationsService;
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
        [Route( "{owner:guid}/Add" )]
        [ResponseType( typeof( ActionResponse<int> ) )]
        public async Task<HttpResponseMessage> List( Guid owner, ParameterizationIn input )
        {
            return await this.ProcessActionAsync( owner, input, this.parameterizationsService.Add );
        }
    }
}