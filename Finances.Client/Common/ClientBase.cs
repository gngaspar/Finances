// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientBase.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the ClientBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client.Common
{
    using System;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    /// <summary>
    /// The client base.
    /// </summary>
    public abstract class ClientBase
    {
        /// <summary>
        /// The JSON accept.
        /// </summary>
        protected const string JsonAccept = "application/json";

        /// <summary>
        /// The JSON content type.
        /// </summary>
        protected const string JsonContentType = "application/json";

        /// <summary>
        /// The sender.
        /// </summary>
        private readonly IRestSender sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientBase"/> class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The Argument Null Exception.
        /// </exception>
        protected ClientBase( IRestSender sender )
        {
            if ( sender == null )
            {
                throw new ArgumentNullException( nameof( sender ) );
            }

            this.sender = sender;
        }

        /// <summary>
        /// The create context xml.
        /// </summary>
        /// <returns>
        /// The <see cref="RestMessageContext"/>.
        /// </returns>
        internal static RestMessageContext CreateContextXml()
        {
            var context = new RestMessageContext
            {
                Accept = JsonAccept,
                ContentType = JsonContentType
            };
            return context;
        }

        /// <summary>
        /// The execute sender.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="TRequest">
        /// The Type of request.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        internal async Task ExecuteSender<TRequest>( TRequest request, RestMessageContext context )
        {
            context.Content = this.SerializeJson( request );
            await this.Execute( context );
        }

        /// <summary>
        /// The execute sender.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="TRequest">
        /// The Type of request.
        /// </typeparam>
        /// <typeparam name="TResponse">
        /// The Type of response.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        internal async Task<TResponse> ExecuteSender<TRequest, TResponse>( TRequest request, RestMessageContext context )
            where TRequest : class
            where TResponse : class
        {
            context.Content = this.SerializeJson( request );
            return await this.ExecuteSender<TResponse>( context );
        }

        /// <summary>
        /// The execute sender.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="TResponse">
        /// The Type of response.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        internal async Task<TResponse> ExecuteSender<TResponse>( RestMessageContext context ) where TResponse : class
        {
            var result = await this.Execute( context );

            return string.IsNullOrEmpty( result.Content ) == false ? this.DeserializeJson<TResponse>( result.Content ) : null;
        }

        /// <summary>
        /// The execute sender.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        internal async Task ExecuteSender( RestMessageContext context )
        {
            await this.Execute( context );
        }

        /// <summary>
        /// The deserialize JSON.
        /// </summary>
        /// <param name="textData">
        /// The text data.
        /// </param>
        /// <typeparam name="T">
        /// The Type to get.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The Argument Null Exception.
        /// </exception>
        protected T DeserializeJson<T>( string textData )
        {
            if ( string.IsNullOrEmpty( textData ) )
            {
                throw new ArgumentNullException( nameof( textData ) );
            }

            return new JavaScriptSerializer().Deserialize<T>( textData );
        }

        /// <summary>
        /// The serialize JSON.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="T">
        /// The Type to get.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The Argument Null Exception.
        /// </exception>
        protected string SerializeJson<T>( T value )
        {
            if ( value == null )
            {
                throw new ArgumentNullException( nameof( value ) );
            }

            return new JavaScriptSerializer().Serialize( value );
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="SerializationException">
        /// The Serialization Exception.
        /// </exception>
        private async Task<IRestResult> Execute( RestMessageContext context )
        {
            var result = await this.sender.CallServiceAsync( context );

            if ( string.Equals( result.ContentType, context.Accept, StringComparison.OrdinalIgnoreCase ) == false )
            {
                throw new SerializationException( "Expected contentType:" + context.Accept );
            }

            return result;
        }
    }
}