// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankClient.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bank client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The bank client.
    /// </summary>
    public class BankClient : ClientBase, IBankController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankClient"/> class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public BankClient( IRestSender sender ) : base( sender )
        {
        }

        ////public Task<BankListResponse> Bankist()
        ////{
        ////    var context = CreateContextXml();

        //// context.HttpMethod = HttpMethod.Post; context.ServiceMethod = ServiceMethod.List;
        //// //context.UrlPath = UrlPrefix + string.Format("/{0}/List", userId);

        ////    //return await this.ExecuteSender<ListRequest, ListResponse>(request, context);
        ////    return new Task<BankListResponse>(new Func<BankListResponse> {Method = { }});

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> Add( BankIn bank )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> Edit( Guid code, BankIn bank )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> List( BankListRequest input )
        {
            throw new NotImplementedException();
        }
    }
}