// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderByField.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the OrderByField type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Extensions
{
    using System.Data.SqlClient;
    using System.Linq;

    using Finances.Contract.Accounting;
    using Finances.Contract.Banking;
    using Finances.Contract.Humans;
    using Finances.Domain.Accounting;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;

    /// <summary>
    /// The order by field.
    /// </summary>
    public static class OrderByField
    {
        /// <summary>
        /// The order by field bank.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <param name="orderByProperty">
        /// The order by property.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<BankEntity> OrderByFieldBank( this IQueryable<BankEntity> entity, SortOrder order, BankField orderByProperty )
        {
            switch ( order )
            {
                case SortOrder.Ascending:

                    switch ( orderByProperty )
                    {
                        case BankField.Country:
                            entity = entity.OrderBy( x => x.Country );
                            break;

                        case BankField.Name:
                            entity = entity.OrderBy( x => x.Name );
                            break;

                        case BankField.Swift:
                            entity = entity.OrderBy( x => x.Swift );
                            break;

                        default:
                            entity = entity.OrderBy( x => x.CreatedAt );
                            break;
                    }

                    break;

                case SortOrder.Descending:

                    switch ( orderByProperty )
                    {
                        case BankField.Country:
                            entity = entity.OrderByDescending( x => x.Country );
                            break;

                        case BankField.Name:
                            entity = entity.OrderByDescending( x => x.Name );
                            break;

                        case BankField.Swift:
                            entity = entity.OrderByDescending( x => x.Swift );
                            break;

                        default:
                            entity = entity.OrderByDescending( x => x.CreatedAt );
                            break;
                    }

                    break;
            }

            return entity;
        }

        /// <summary>
        /// The order by field person.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <param name="orderByProperty">
        /// The order by property.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<PersonEntity> OrderByFieldPerson( this IQueryable<PersonEntity> entity, SortOrder order, HumanField orderByProperty )
        {
            switch ( order )
            {
                case SortOrder.Ascending:

                    switch ( orderByProperty )
                    {
                        case HumanField.Name:
                            entity = entity.OrderBy( x => x.Name );
                            break;

                        case HumanField.Email:
                            entity = entity.OrderBy( x => x.Email );
                            break;

                        case HumanField.Surname:
                            entity = entity.OrderBy( x => x.Surname );
                            break;

                        default:
                            entity = entity.OrderBy( x => x.CreatedAt );
                            break;
                    }

                    break;

                case SortOrder.Descending:

                    switch ( orderByProperty )
                    {
                        case HumanField.Name:
                            entity = entity.OrderByDescending( x => x.Name );
                            break;

                        case HumanField.Email:
                            entity = entity.OrderByDescending( x => x.Email );
                            break;

                        case HumanField.Surname:
                            entity = entity.OrderByDescending( x => x.Surname );
                            break;

                        default:
                            entity = entity.OrderByDescending( x => x.CreatedAt );
                            break;
                    }

                    break;
            }

            return entity;
        }

        /// <summary>
        /// The order by field account.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <param name="orderByProperty">
        /// The order by property.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<AccountEntity> OrderByFieldAccount( this IQueryable<AccountEntity> entity, SortOrder order, AccountField orderByProperty )
        {
            switch ( order )
            {
                case SortOrder.Ascending:

                    switch ( orderByProperty )
                    {
                        case AccountField.Description:
                            entity = entity.OrderBy( x => x.Description );
                            break;

                        default:
                            entity = entity.OrderBy( x => x.CreatedAt );
                            break;
                    }

                    break;

                case SortOrder.Descending:

                    switch ( orderByProperty )
                    {
                        case AccountField.Description:
                            entity = entity.OrderByDescending( x => x.Description );
                            break;

                        default:
                            entity = entity.OrderByDescending( x => x.CreatedAt );
                            break;
                    }

                    break;
            }

            return entity;
        }
    }
}