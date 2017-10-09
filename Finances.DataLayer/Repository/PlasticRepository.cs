// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlasticRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The plastic repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;
    using Finances.Contract.Common;
    using Finances.Contract.Plastics;
    using Finances.Domain;
    using Finances.Domain.Extensions;
    using Finances.Domain.Plastic;
    using Finances.Domain.Repository;

    /// <summary>
    /// The plastic repository.
    /// </summary>
    public class PlasticRepository : IPlasticRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BankingDbContext context;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private ICacheProvider cacheProvider;

        /// <summary>
        /// The human repository.
        /// </summary>
        private IHumanRepository humanRepository;

        /// <summary>
        /// The account repository.
        /// </summary>
        private IAccountRepository accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlasticRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        /// <param name="humanRepository">
        /// The human Repository.
        /// </param>
        /// <param name="accountRepository">
        /// The account Repository.
        /// </param>
        /// <param name="cacheProvider">
        /// The cache Provider.
        /// </param>
        public PlasticRepository( BankingDbContext bankingDbContext, IHumanRepository humanRepository, IAccountRepository accountRepository, Domain.ICacheProvider cacheProvider )
        {
            this.context = bankingDbContext;
            this.humanRepository = humanRepository;
            this.cacheProvider = cacheProvider;
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CardListResponse> List( Guid owner, CardListRequest input )
        {
            IQueryable<CardEntity> listQuery = this.context.Cards.Where( o => o.Owner == owner
                        && ( ( !input.Filter.BringArchived && !o.IsArchived ) || input.Filter.BringArchived ) );

            if ( !string.IsNullOrEmpty( input.Filter.Description ) )
            {
                listQuery = input.Filter.DescriptionExact ?
                        listQuery.Where( x => x.Description == input.Filter.Description ) :
                        listQuery.Where( x => x.Description.Contains( input.Filter.Description ) );
            }

            if ( input.Filter.FilterByAccount )
            {
                listQuery = listQuery.Where( x => x.Account == input.Filter.Account );
            }

            if ( input.Filter.FilterByBank )
            {
                listQuery = listQuery.Where( x => x.Bank == input.Filter.Bank );
            }

            if ( input.Filter.FilterByCurrency && !string.IsNullOrEmpty( input.Filter.Currency ) )
            {
                listQuery = listQuery.Where( x => x.Currency == input.Filter.Currency );
            }

            if ( input.Filter.FilterByHolder && !input.Filter.BringOnlyMine )
            {
                listQuery = listQuery.Where( x => x.Holder == input.Filter.Holder );
            }

            if ( input.Filter.BringOnlyMine )
            {
                listQuery = listQuery.Where( x => x.Holder == owner );
            }

            if ( !string.IsNullOrEmpty( input.Filter.Number ) )
            {
                listQuery = listQuery.Where( x => x.CardNumber.Contains( input.Filter.Number ) );
            }

            listQuery = listQuery.Where( x =>
                 ( input.Filter.Types.Contains( CardType.CreditCard ) && x is CreditCardEntity )
                 || ( input.Filter.Types.Contains( CardType.DebitCard ) && x is DebitCardEntity )
                 || ( input.Filter.Types.Contains( CardType.PrePaidCard ) && x is PrePaidCardEntity ) );

            var queryResult = await listQuery.CountAsync();

            var orderType = input.Order.IsDesc ? SortOrder.Descending : SortOrder.Ascending;

            var list = await listQuery
                        .OrderByFieldCard( orderType, input.Order.Field )
                        .Skip( ( input.Page - 1 ) * input.ItemsPerPage )
                        .Take( input.ItemsPerPage )
                        .Select( order => new
                        {
                            order.Code,
                            order.Description,
                            order.Currency,
                            order.Holder,
                            order.Bank,
                            order.ChangeAt,
                            order.CreatedAt,
                            order.IsArchived,
                            order.CardProviderString,
                            order.CardNumber,
                            order.Expire,
                            Type = order is CreditCardEntity ? CardType.CreditCard : order is DebitCardEntity ? CardType.DebitCard : CardType.PrePaidCard
                        } ).ToListAsync();

            var listOfHolderGuids = list.GroupBy( o => o.Holder ).Select( g => g.Key ).ToList();
            var listOfHolders = await this.humanRepository.GetList( owner, listOfHolderGuids );

            var listOfAccountsGuids = list.GroupBy( o => o.Code ).Select( g => g.Key ).ToList();
            var listOfAccounts = await this.accountRepository.List( owner, listOfAccountsGuids );
            var result = new CardListResponse
            {
                NumberOfItems = queryResult,
                Data = list.Select( order => new Card
                {
                    Code = order.Code,
                    Description = order.Description,
                    Currency = this.cacheProvider.Currencies.FirstOrDefault( o => o.Code == order.Currency ),
                    Holder = listOfHolders.FirstOrDefault( i => i.Code == order.Holder ),
                    Bank = this.cacheProvider.Banks.FirstOrDefault( o => o.Code == order.Bank ),
                    ChangeAt = order.ChangeAt,
                    CreatedAt = order.CreatedAt,
                    IsArchived = order.IsArchived,
                    Type = order.Type,
                    CardProvider = (CardProvider) Enum.Parse( typeof( CardProvider ), order.CardProviderString ),
                    CardNumber = order.CardNumber,
                    Expire = order.Expire,
                    Account = listOfAccounts.FirstOrDefault( i => i.Code == order.Code )
                } ).ToList()
            };

            return result;
        }
    }
}