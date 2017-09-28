// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The base controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Finances.Contract;
    using Finances.Domain;
    using Finances.Endpoint.WebApi.Infrastructure.Logs;
    using Finances.Endpoint.WebApi.Infrastructure.Validation;

    /// <summary>
    /// The base controller.
    /// </summary>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// The validator filed.
        /// </summary>
        private static readonly Lazy<InputValidation> ValidatorFiled = new Lazy<InputValidation>( () => new InputValidation() );

        /// <summary>
        /// Gets the validator.
        /// </summary>
        /// <value>
        /// The validator.
        /// </value>
        protected InputValidation Validator => ValidatorFiled.Value;

        /// <summary>
        /// The process action async.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <typeparam name="TResp">
        /// The type of request.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected async Task<HttpResponseMessage> ProcessActionAsync<TResp>( Func<Task<TResp>> method )
        {
            var output = new ActionResponse<TResp>();
            var statusCode = HttpStatusCode.OK;
            try
            {
                output.HasError = false;
                output.Results = await method();
            }
            catch ( Exception ex )
            {
                var financesException = new FinancesException( ex.GetType().Name, ex );
                EventViewerLogger.LogException( financesException );
                output.ErrorMessage = ex.Message;
                output.ErrorGuid = financesException.ErrorCode.ToString();
                output.HasError = true;
                statusCode = HttpStatusCode.InternalServerError;
            }

            return this.Request.CreateResponse( statusCode, output );
        }

        /// <summary>
        /// The process action async.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <typeparam name="TReq">
        /// Request type.
        /// </typeparam>
        /// <typeparam name="TResp">
        /// Response type.
        /// </typeparam>
        /// <returns>
        /// The response.
        /// </returns>
        protected async Task<HttpResponseMessage> ProcessActionAsync<TReq, TResp>( TReq request, Func<TReq, Task<TResp>> method )
        {
            var output = new ActionResponse<TResp>();
            var statusCode = HttpStatusCode.OK;
            try
            {
                output.HasError = false;
                output.Results = await method( request );
            }
            catch ( Exception ex )
            {
                var financesException = new FinancesException( ex.GetType().Name, ex );
                EventViewerLogger.LogException( financesException );
                output.ErrorMessage = ex.Message;
                output.ErrorGuid = financesException.ErrorCode.ToString();
                output.HasError = true;
                statusCode = HttpStatusCode.InternalServerError;
            }

            return this.Request.CreateResponse( statusCode, output );
        }

        /// <summary>
        /// The process action async.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <typeparam name="Guid">
        /// The guid.
        /// </typeparam>
        /// <typeparam name="TReq">
        /// The type of request.
        /// </typeparam>
        /// <typeparam name="TResp">
        /// The type of Response.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected async Task<HttpResponseMessage> ProcessActionAsync<TReq, TResp>( Guid owner, TReq input, Func<Guid, TReq, Task<TResp>> method )
        {
            var output = new ActionResponse<TResp>();
            var statusCode = HttpStatusCode.OK;
            try
            {
                output.HasError = false;
                output.Results = await method( owner, input );
            }
            catch ( Exception ex )
            {
                var financesException = new FinancesException( ex.GetType().Name, ex );
                EventViewerLogger.LogException( financesException );
                output.ErrorMessage = ex.Message;
                output.ErrorGuid = financesException.ErrorCode.ToString();
                output.HasError = true;
                statusCode = HttpStatusCode.InternalServerError;
            }

            return this.Request.CreateResponse( statusCode, output );
        }
    }
}