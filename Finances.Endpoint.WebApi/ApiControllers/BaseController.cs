namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Finances.Contract;

    /// <summary>
    /// The base controller.
    /// </summary>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// The process action async.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <typeparam name="TResp">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected async Task<HttpResponseMessage> ProcessActionAsync<TResp>(Func<Task<TResp>> method)
        {
            var output = new ActionResponse<TResp>();
            var statusCode = HttpStatusCode.OK;
            try
            {
                output.HasError = false;
                output.Results = await method();

            }
            catch (Exception ex)
            {
                output.ErrorMessage = ex.Message;
                output.HasError = true;
                statusCode = HttpStatusCode.InternalServerError;
            }

            return this.Request.CreateResponse(statusCode, output);
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
        protected async Task<HttpResponseMessage> ProcessActionAsync<TReq, TResp>(TReq request, Func<TReq, Task<TResp>> method)
        {
            var output = new ActionResponse<TResp>();
            var statusCode = HttpStatusCode.OK;
            try
            {
                output.HasError = false;
                output.Results = await method(request);
  
            }
            catch (Exception ex)
            {
                output.ErrorMessage = ex.Message;
                output.HasError = true;
                statusCode = HttpStatusCode.InternalServerError;
            }
            
            return this.Request.CreateResponse(statusCode, output);
        }
    }
}