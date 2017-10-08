// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputValidation.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The input validation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.Infrastructure.Validation
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Finances.Contract;

    using Newtonsoft.Json;

    /// <summary>
    /// The input validation.
    /// </summary>
    public sealed class InputValidation
    {
        /// <summary>
        /// The page.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="InputValidation"/>.
        /// </returns>
        public InputValidation Page( IListRequest request )
        {
            if ( request.Page < 1 )
            {
                Throw( "Page must be bigger then 0" );
            }

            return this;
        }

        /// <summary>
        /// The items.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="InputValidation"/>.
        /// </returns>
        public InputValidation Items( IListRequest request )
        {
            if ( request.ItemsPerPage < 1 )
            {
                Throw( "Page must be bigger then 0" );
            }

            return this;
        }

        /// <summary>
        /// The throw.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <exception cref="HttpResponseException">
        /// Http Response Exception.
        /// </exception>
        private static void Throw( string message )
        {
            var output = new ActionResponse<object> { ErrorMessage = message, HasError = true, ErrorGuid = "FF00CF8C-A694-4E4B-9E18-48E5FE7271BD" };

            var resp = new HttpResponseMessage( HttpStatusCode.BadRequest )
            {
                Content = new StringContent( JsonConvert.SerializeObject( output ) )
            };
            throw new HttpResponseException( resp );
        }
    }
}