// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bank service implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Management
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The bank service implementation.
    /// </summary>
    /// <seealso cref="Finances.Domain.IBankService"/>
    public class BankService : IBankService
    {
        /// <summary>
        /// The bank repository
        /// </summary>
        private readonly IBankRepository bankRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="bankRepository">The bank repository.</param>
        public BankService( IBankRepository bankRepository )
        {
            this.bankRepository = bankRepository;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<Guid> Add( BankIn bank )
        {
            ValidateBankIn( bank );

            var existBySwift = await this.bankRepository.ExistsBySwift( bank.Swift );
            if ( existBySwift )
            {
                throw new Exception( $"Swift {bank.Swift} already exists." );
            }

            var code = Guid.NewGuid();

            var result = await this.bankRepository.Add( code, bank );

            return result != 0 ? code : Guid.Empty;
        }

        /// <summary>
        /// The edit of an Bank.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<bool> Edit( BankEdit bank )
        {
            ValidateBankIn( bank.Bank );

            var existCode = await this.bankRepository.ExistsByCode( bank.Code );
            if ( !existCode )
            {
                throw new Exception( $"Bank with {bank.Code} doesnt exists." );
            }

            var existInOther = await this.bankRepository.ThisSwiftExistsInOther( bank.Code, bank.Bank.Swift );
            if ( !existInOther )
            {
                throw new Exception( $"The Swift {bank.Bank.Swift} exists in a bank with a diferent then {bank.Code} ." );
            }

            var result = await this.bankRepository.Edit( bank.Code, bank.Bank );

            return result != 0;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<BankListResponse> List( BankListRequest request )
        {
            if ( request == null )
            {
                throw new ArgumentNullException( nameof( request ) );
            }

            if ( request.Page == 0 )
            {
                throw new Exception( "Page must be bigger then 0." );
            }

            if ( request.ItemsPerPage == 0 )
            {
                throw new Exception( "ItemsPerPage must be bigger then 0." );
            }

            if ( request.Filter == null )
            {
                throw new ArgumentNullException( nameof( request.Filter ) );
            }

            if ( request.Order == null )
            {
                throw new ArgumentNullException( nameof( request.Order ) );
            }

            return await this.bankRepository.List( request );
        }

        /// <summary>
        /// Validates the bank in.
        /// </summary>
        /// <param name="bank">The bank.</param>
        private static void ValidateBankIn( BankIn bank )
        {
            if ( bank == null )
            {
                throw new ArgumentNullException( nameof( bank ) );
            }

            if ( string.IsNullOrEmpty( bank.Swift ) )
            {
                throw new NullReferenceException( "Swift must not be null." );
            }

            if ( bank.Swift.Length > 50 )
            {
                throw new Exception( "Swift is longer then 50." );
            }

            if ( string.IsNullOrEmpty( bank.Country ) )
            {
                throw new NullReferenceException( "Country must not be null." );
            }

            if ( bank.Country.Length > 5 )
            {
                throw new Exception( "Country is longer then 5." );
            }

            if ( string.IsNullOrEmpty( bank.Name ) )
            {
                throw new NullReferenceException( "Name must not be null." );
            }

            if ( bank.Name.Length > 100 )
            {
                throw new Exception( "Name is longer then 100." );
            }

            if ( bank.Name.Length < 2 )
            {
                throw new Exception( "Name is smaller then 2." );
            }

            if ( string.IsNullOrEmpty( bank.Url ) )
            {
                throw new NullReferenceException( "Url must not be null." );
            }

            if ( bank.Url.Length > 100 )
            {
                throw new Exception( "Url is longer then 250." );
            }
        }
    }
}